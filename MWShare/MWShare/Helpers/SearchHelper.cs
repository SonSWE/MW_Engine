using Business.Core.BLs;
using CommonLib.Constants;
using MemoryData;
using Object.Core;
using System.Data;

namespace MWShare.Helpers
{
    public interface ISearchHelper
    {
        Search? GetSearchConfigs(string code, bool includeExportColumn, out List<SearchFld>? fldsAllowFilter, out List<SearchFld>? fldsAllowDisplay, out List<string>? recordKeys);
        DataSet? Inquiry(SearchInquiry request, int maxRecordShow, out int pageCount, out int recordCount, out int realRecordCount, out long maxAutoId);
    }

    public sealed class SearchHelper : ISearchHelper
    {
        private readonly ISearchBL _searchBL;

        public SearchHelper(ISearchBL searchBL)
        {
            _searchBL = searchBL;
        }

        //
        public Search? GetSearchConfigs(string code, bool includeExportColumn, out List<SearchFld>? fldsAllowFilter, out List<SearchFld>? fldsAllowDisplay, out List<string>? recordKeys)
        {
            Search search = new();
            fldsAllowFilter = new List<SearchFld>();
            fldsAllowDisplay = new List<SearchFld>();
            recordKeys = new List<string>();

            if (string.IsNullOrEmpty(code)) return search;

            search = SearchMem.GetByCode(code);
            if (search != null && search.Code.Equals(code))
            {
                var searchFlds = SearchMem.SearchFldGetBySearchCode(code);

                fldsAllowFilter = searchFlds?.Where(x => x.Srch?.Equals(Const.YN.Yes) == true).OrderBy(x => x.Position).ThenBy(x => x.FldCode).ToList();

                fldsAllowDisplay = searchFlds?.Where(x =>
                    string.Equals(x.Display, Const.Search.Display.Yes, StringComparison.OrdinalIgnoreCase)
                    || (includeExportColumn && string.Equals(x.Display, Const.Search.Display.Export, StringComparison.OrdinalIgnoreCase))
                ).OrderBy(x => x.Position).ThenBy(x => x.FldCode).ToList();

                recordKeys = searchFlds?.Where(x => x.IsRecordKey?.Equals(Const.YN.Yes) == true).OrderBy(x => x.Position).Select(x => x.FldCode).ToList();
            }

            return search;
        }

        public DataSet? Inquiry(SearchInquiry request, int maxRecordShow, out int pageCount, out int recordCount, out int realRecordCount, out long maxAutoId)
        {
            pageCount = 0;
            recordCount = 0;
            realRecordCount = 0;
            maxAutoId = 0;

            if (request == null || string.IsNullOrEmpty(request.Code)) return default;

            if (request.PageSize <= 0) request.PageSize = 100;
            if (request.PageSize > 500) request.PageSize = 500;
            if (request.PageNum <= 0) request.PageNum = 1;

            int fromRecord = (request.PageSize * (request.PageNum - 1)) + 1;
            int toRecord = request.PageSize * request.PageNum;

            if (request.IsExport == 1)
            {
                fromRecord = -1;
                toRecord = -1;
                maxRecordShow = int.MaxValue;
            }

            //
            var searchConds = new List<SearchInquiryCond>();
            var sortConds = new List<string>();
            var search = GetSearchConfigs(request.Code, false, out List<SearchFld>? fldsAllowFilter, out List<SearchFld>? fldsAllowDisplay, out List<string>? recordKeys);

            if (search == null || string.IsNullOrEmpty(search.Code)) return default;

            // Check dieu kiem tim kiem. Truyen vao DB dung thu tu dinh nghia
            if (fldsAllowFilter?.Count > 0)
            {
                foreach (var item in fldsAllowFilter)
                {
                    if (item == null || string.IsNullOrEmpty(item.FldCode)) continue;

                    var cond = request.Conds?.FirstOrDefault(x => x.Key.Equals(item.FldCode, StringComparison.OrdinalIgnoreCase));
                    if (cond == null)
                    {
                        searchConds.Add(new SearchInquiryCond
                        {
                            Key = item.FldCode,
                            Value = string.Empty,
                            Operator = string.Empty,
                            DataType = item.DataType,
                            Control = item.Control,
                        });
                    }
                    else
                    {
                        searchConds.Add(new SearchInquiryCond
                        {
                            Key = item.FldCode,
                            Value = cond.Value,
                            Operator = item.Control?.Equals(Const.Search.Control.ComboMultiple) == true ? Const.Search.Operator.In : cond.Operator,
                            DataType = item.DataType,
                            Control = item.Control,
                        });
                    }
                }
            }

            // Check sort
            if (request.SortConds?.Count > 0)
            {
                foreach (var sortCond in request.SortConds)
                {
                    if (sortCond == null || string.IsNullOrEmpty(sortCond.Key)) continue;

                    var fld = fldsAllowDisplay?.FirstOrDefault(x => x.FldCode?.Equals(sortCond.Key, StringComparison.OrdinalIgnoreCase) == true && x.AllowSort?.Equals(Const.YN.Yes) == true);

                    if (Const.Search.SortDirection.IsValid(sortCond.Direction) && fld != null)
                    {
                        if (string.IsNullOrEmpty(fld.DataType) || fld.DataType == Const.Search.DataType.String)
                            sortConds.Add($"nlssort({sortCond.Key},'NLS_SORT=VIETNAMESE') {sortCond.Direction ?? string.Empty}");
                        else
                            sortConds.Add($"{sortCond.Key} {sortCond.Direction ?? string.Empty}");
                    }
                }
            }

            //
            DataSet ds = null;
            bool isInquiryOptimize = false;

            if (string.Equals(search.UseSqlText, Const.YN.Yes, StringComparison.OrdinalIgnoreCase) && !string.Equals(search.PassCondAsArray, Const.Search.PassCondAsArray.Optimize, StringComparison.OrdinalIgnoreCase))
            {
                ds = _searchBL.InquiryPageUseSqlText(search.StoreName, searchConds, sortConds, request.Language, fromRecord, toRecord, maxRecordShow, out recordCount);
            }
            else if (string.Equals(search.UseSqlText, Const.YN.Yes, StringComparison.OrdinalIgnoreCase))
            {
                isInquiryOptimize = true;
                ds = _searchBL.InquiryUseSqlText(search.StoreName, searchConds, sortConds, request.Language, maxRecordShow, out realRecordCount, out maxAutoId);
            }
            else if (search.PassCondAsArray?.Equals(Const.Search.PassCondAsArray.Optimize, StringComparison.OrdinalIgnoreCase) == true)
            {
                isInquiryOptimize = true;
                ds = _searchBL.InquiryOptimize(search.StoreName, searchConds, sortConds, request.Language, maxRecordShow, out realRecordCount, out maxAutoId);
            }
            else if (search.PassCondAsArray?.Equals(Const.Search.PassCondAsArray.Yes, StringComparison.OrdinalIgnoreCase) == true)
            {
                ds = _searchBL.InquiryArray(search.StoreName, searchConds, sortConds, request.Language, fromRecord, toRecord, out recordCount);
            }
            else
            {
                ds = _searchBL.Inquiry(search.StoreName, searchConds, sortConds, request.Language, fromRecord, toRecord, out recordCount);
            }

            //
            pageCount = (int)Math.Ceiling((decimal)recordCount / request.PageSize);
            if (isInquiryOptimize && ds?.Tables.Count > 0)
            {
                recordCount = ds.Tables[0].Rows.Count;
            }

            //
            return ds;
        }
    }
}
