using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.Interfaces
{
    public interface ISearchDA
    {
        List<Search> GetAll();

        List<SearchFld> SearchFldGetAll();

        List<SearchFilterOption> GetSearchFilterOptions(string sqlCmd);

        DataSet Inquiry(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount);
        DataSet InquiryArray(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount);
        DataSet InquiryOptimize(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId);
        DataSet InquiryUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId);
        DataSet InquiryPageUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, int maxRecordShow, out int recordCount);
    }
}
