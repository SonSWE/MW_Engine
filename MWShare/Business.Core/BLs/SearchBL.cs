using DataAccess.Core.Interfaces;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace Business.Core.BLs
{
    public class SearchBL : ISearchBL
    {
        private readonly ISearchDA _searchDA;

        public SearchBL(ISearchDA searchDA)
        {
            _searchDA = searchDA;
        }

        //
        public List<Search> GetAll()
        {
            return _searchDA.GetAll();
        }

        public List<SearchFld> SearchFldGetAll()
        {
            return _searchDA.SearchFldGetAll();
        }

        public List<SearchFilterOption> GetSearchFilterOptions(string sqlCmd)
        {
            return _searchDA.GetSearchFilterOptions(sqlCmd);
        }

        public DataSet Inquiry(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount)
        {
            return _searchDA.Inquiry(storeName, searchConds, sortConds, language, fromRecord, toRecord, out recordCount);
        }

        public DataSet InquiryArray(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount)
        {
            return _searchDA.InquiryArray(storeName, searchConds, sortConds, language, fromRecord, toRecord, out recordCount);
        }

        public DataSet InquiryOptimize(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId)
        {
            return _searchDA.InquiryOptimize(storeName, searchConds, sortConds, language, maxRecordShow, out realRecordCount, out maxAutoId);
        }

        public DataSet InquiryUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId)
        {
            return _searchDA.InquiryUseSqlText(sqlText, searchConds, sortConds, language, maxRecordShow, out realRecordCount, out maxAutoId);
        }

        public DataSet InquiryPageUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, int maxRecordShow, out int recordCount)
        {
            return _searchDA.InquiryPageUseSqlText(sqlText, searchConds, sortConds, language, fromRecord, toRecord, maxRecordShow, out recordCount);
        }
    }
}
