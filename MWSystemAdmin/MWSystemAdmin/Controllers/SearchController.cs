using Business.Core.BLs;
using CommonLib;
using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Helpers;
using MemoryData;
using Microsoft.AspNetCore.Mvc;
using MWShare.FilterAttributes;
using MWShare.Helpers;
using Object.Core;
using Object.Core.CustomAttributes;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Reflection;

namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchBL _searchBL;
        private readonly ISearchHelper _searchHelper;
        private readonly ILoggingManagement _loggingManagement;


        public SearchController(ISearchBL searchBL, ISearchHelper searchHelper, ILoggingManagement loggingManagement)
        {
            _searchBL = searchBL;
            _searchHelper = searchHelper;
            _loggingManagement = loggingManagement;
        }

        private string _requestId => _loggingManagement.RequestId;

        [ApiAuthorize(CheckFunction = false)]
        [HttpPost, Route("inquiry")]
        public async Task<IActionResult> Inquiry([FromBody] SearchInquiry searchInquiry)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            try
            {
                var search = GetByCodeHandle(searchInquiry?.Code ?? string.Empty);
                string functionIdToCheck = search?.FunctionId ?? string.Empty;

                //tạm bỏ vì chưa tạo chức năng phân quyền
                //if (!CheckUserRight(clientInfo?.LoggedUser, functionIdToCheck))
                //{
                //    return StatusCode(StatusCodes.Status403Forbidden);
                //}

                //
                return await Task.Factory.StartNew(() => InquiryHandle(searchInquiry));

            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{_requestId}] {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                Logger.logData.Info(JsonHelper.Serialize(new
                {
                    _requestId,
                    requestTime,
                    responseTime = DateTime.Now,
                    processTime = ConstLog.GetProcessingMilliseconds(requestTime),
                    peer = clientInfo?.IpAddress,
                    request = searchInquiry,
                }));
            }
        }

        //
        #region Private functions

        private bool CheckUserRight(LoggedUser loggedUser, string functionId)
        {
            if (string.Equals(functionId, Const.AuthenFunctionId.Any, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            functionId ??= string.Empty;
            var function = loggedUser?.FunctionSettings?.Find(x => string.Equals(x.FunctionId, functionId));
            return string.Equals(function?.AllowQuery, Const.YN.Yes);
        }

        private SearchGetByCodeResponse GetByCodeHandle(string code)
        {
            SearchGetByCodeResponse searchGetByCodeResponse = new();

            if (string.IsNullOrEmpty(code)) return searchGetByCodeResponse;

            var search = _searchHelper.GetSearchConfigs(code);

            if (search == null) return searchGetByCodeResponse;

            //
            searchGetByCodeResponse.Code = search.Code ?? string.Empty;
            searchGetByCodeResponse.Title = search.Title ?? string.Empty;
            searchGetByCodeResponse.FunctionId = search.FunctionId ?? string.Empty;

            //#endregion

            return searchGetByCodeResponse;
        }

        private IActionResult InquiryHandle(SearchInquiry searchInquiry)
        {
            if (searchInquiry == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (searchInquiry.PageSize <= 0) searchInquiry.PageSize = 100;
            if (searchInquiry.PageSize > 500) searchInquiry.PageSize = 500;
            if (searchInquiry.PageNum <= 0) searchInquiry.PageNum = 1;

            int fromRecord = (searchInquiry.PageSize * (searchInquiry.PageNum - 1)) + 1;
            int toRecord = searchInquiry.PageSize * searchInquiry.PageNum;
            int maxRecordShow = SysParamMem.GetMaxRecordShow();

            //
            var ds = _searchHelper.Inquiry(searchInquiry, maxRecordShow, out int pageCount, out int recordCount, out int realRecordCount, out long maxAutoId);

            // Tim kiem du lieu thì convert DataTable sang list roi gui ve
            SearchInquiryResponse searchInquiryResponse = new();

            searchInquiryResponse.RecordCount = recordCount;
            searchInquiryResponse.PageCount = pageCount;
            searchInquiryResponse.PageSize = searchInquiry.PageSize;
            searchInquiryResponse.PageNum = searchInquiry.PageNum;

            searchInquiryResponse.RealRecordCount = realRecordCount;
            searchInquiryResponse.MaxRecordShow = maxRecordShow;
            searchInquiryResponse.MaxAutoId = maxAutoId;

            if (ds != null && ds.Tables.Count > 0)
            {
                searchInquiryResponse.Datas = ListFromDataTable(searchInquiry.Code, ds.Tables[0]);
            }

            return StatusCode(StatusCodes.Status200OK, searchInquiryResponse);

        }

        private List<ExpandoObject> ListFromDataTable(string searchCode, DataTable srcTable)
        {
            List<ExpandoObject> results = new();

            if (srcTable == null || srcTable.Rows.Count == 0)
            {
                return results;
            }

            var searchPropertys = new List<SearchProperty>();
            var search = _searchHelper.GetSearchConfigs(searchCode);

            if (search != null && !string.IsNullOrEmpty(search.NameSpace) && !string.IsNullOrEmpty(search.ClassName))
            {
                string fullClassName = $"{search.NameSpace}.{search.ClassName}";
                Assembly assembly = Assembly.Load(search.NameSpace);
                Type type = assembly.GetType(fullClassName);
                if (type != null)
                {
                    // Lấy danh sách thuộc tính
                    var properties = type.GetProperties().Where(x => x.GetCustomAttribute<DbFieldAttribute>() == null || x.GetCustomAttribute<DbFieldAttribute>()?.IsDetailTable != true);

                    foreach (var property in properties)
                    {
                        var atr = property.GetCustomAttribute<DbFieldAttribute>() ?? new();

                        searchPropertys.Add(new SearchProperty()
                        {
                            Name = property.Name.ToCamelCase(),
                            DataType = !string.IsNullOrEmpty(atr.DataType) ? atr.DataType : Const.Search.DataType.String,
                        });
                    }
                }


            }


            //
            for (int i = 0; i < srcTable.Rows.Count; i++)
            {
                DataRow dr = srcTable.Rows[i];
                ExpandoObject obj = new();
                IDictionary<string, object> dicData = obj as IDictionary<string, object>;

                foreach (var fld in searchPropertys)
                {
                    if (dr.Table.Columns.Contains(fld.Name.ToUpper()))
                    {
                        var getValue = dr[fld.Name.ToUpper()];

                        //
                        if (getValue == null || getValue == DBNull.Value)
                        {
                            dicData.Add(fld.Name, null);
                            continue;
                        }

                        //
                        var getType = getValue.GetType();
                        var getTypeCode = System.Type.GetTypeCode(getValue?.GetType());

                        object[] agrs = null;
                        if (getTypeCode == TypeCode.DateTime)
                        {
                            agrs = new object[] { "O", CultureInfo.InvariantCulture };
                        }
                        string getValueStr = getType.InvokeMember("ToString",
                                     BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                                     , null, getValue, agrs) as string ?? string.Empty;

                        switch (fld.DataType)
                        {
                            case Const.Search.DataType.Int:
                            case Const.Search.DataType.DateNumber:
                                _ = int.TryParse(getValueStr, out int intValue);
                                dicData.Add(fld.Name, intValue);
                                break;
                            case Const.Search.DataType.Long:
                                _ = long.TryParse(getValueStr, out long longValue);
                                dicData.Add(fld.Name, longValue);
                                break;
                            case Const.Search.DataType.Double:
                            case Const.Search.DataType.Double0:
                            case Const.Search.DataType.Double1:
                            case Const.Search.DataType.Double2:
                            case Const.Search.DataType.Double3:
                            case Const.Search.DataType.Double4:
                                _ = double.TryParse(getValueStr, out double doubleValue);
                                dicData.Add(fld.Name, doubleValue);
                                break;
                            case Const.Search.DataType.Date:
                            case Const.Search.DataType.Date10:
                            case Const.Search.DataType.Date16:
                            case Const.Search.DataType.Date19:
                            case Const.Search.DataType.Date23:
                                _ = DateTime.TryParse(getValueStr, out DateTime dateValue);
                                if (dateValue.Date != DateTime.MinValue.Date && dateValue.Kind == DateTimeKind.Unspecified)
                                {
                                    dicData.Add(fld.Name, DateTime.SpecifyKind(dateValue, DateTimeKind.Local));
                                }
                                else
                                {
                                    dicData.Add(fld.Name, dateValue);
                                }
                                break;
                            default:
                                dicData.Add(fld.Name, getValueStr);
                                break;
                        }
                    }
                }

                results.Add(obj);
            }

            return results;
        }

        #endregion
    }
}
