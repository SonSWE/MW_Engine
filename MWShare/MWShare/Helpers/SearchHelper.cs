using Business.Core.BLs;
using CommonLib.Constants;
using MemoryData;
using Object.Core;
using System.Data;

namespace MWShare.Helpers
{
    public interface ISearchHelper
    {
        Search? GetSearchConfigs(string code);
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
        public Search? GetSearchConfigs(string code)
        {
            Search search = new();

            if (string.IsNullOrEmpty(code)) return search;

            search = SearchMem.GetByCode(code);

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

            //
            var searchConds = new List<SearchInquiryCond>();
            var sortConds = new List<string>();

            var search = GetSearchConfigs(request.Code);
            if (request.Conds?.Count > 0)
            {
                foreach (var item in request.Conds)
                {
                    searchConds.Add(new SearchInquiryCond
                    {
                        Key = item.Key,
                        Value = item.Value,
                        Operator = item.Control?.Equals(Const.Search.Control.ComboMultiple) == true ? Const.Search.Operator.In : item.Operator,
                        DataType = item.DataType,
                        Control = item.Control,
                    });
                }
            }

            // Check sort
            if (request.SortConds?.Count > 0)
            {
                foreach (var sortCond in request.SortConds)
                {
                    if (sortCond == null || string.IsNullOrEmpty(sortCond.Key)) continue;
                    
                    if (string.IsNullOrEmpty(sortCond.DataType) || sortCond.DataType == Const.Search.DataType.String)
                        sortConds.Add($"nlssort({sortCond.Key},'NLS_SORT=VIETNAMESE') {sortCond.Direction ?? string.Empty}");
                    else
                        sortConds.Add($"{sortCond.Key} {sortCond.Direction ?? string.Empty}");
                }
            }

            //
            DataSet ds = null;
            bool isInquiryOptimize = false;

            //mặc định tìm kiếm dữ liệu bằng sql text
            isInquiryOptimize = true;
            ds = _searchBL.InquiryUseSqlText(search.StoreName, searchConds, sortConds, request.Language, maxRecordShow, out realRecordCount, out maxAutoId);

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
