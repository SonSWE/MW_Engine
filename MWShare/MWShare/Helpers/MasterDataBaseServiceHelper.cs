using Object.Core;

namespace MWShare.Helpers
{
    public interface IMasterDataBaseServiceHelper
    {
        List<long> GetAutoIdsFromSearch(SearchInquiry searchInquiry, long maxAutoId, List<long> autoIdsIgnored, out List<string> recordActions);
        List<string> GetIdsFromSearch(SearchInquiry searchInquiry, string idField, List<string> idsIgnored, out List<string> recordActions);
    }

    public sealed class MasterDataBaseServiceHelper : IMasterDataBaseServiceHelper
    {
        private readonly ISearchHelper _searchHelper;

        public MasterDataBaseServiceHelper(ISearchHelper searchHelper)
        {
            _searchHelper = searchHelper;
        }

        public List<long> GetAutoIdsFromSearch(SearchInquiry searchInquiry, long maxAutoId, List<long> autoIdsIgnored, out List<string> recordActions)
        {
            recordActions = new();
            List<long> autoIds = new();

            if (searchInquiry != null)
            {
                searchInquiry.IsExport = 1;
                var ds = _searchHelper.Inquiry(searchInquiry, int.MaxValue, out _, out _, out _, out _);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    bool isAutoIdExisted = ds.Tables[0].Columns.Contains("AUTOID");
                    bool isActionExisted = ds.Tables[0].Columns.Contains("ACTION");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var dr = ds.Tables[0].Rows[i];

                        var autoId = isAutoIdExisted ? Convert.ToInt64(dr["AUTOID"]) : 0;
                        if (autoId > maxAutoId || autoIdsIgnored?.Any(x => x == autoId) == true)
                            continue;

                        //
                        var action = isActionExisted ? Convert.ToString(dr["ACTION"]) ?? string.Empty : string.Empty;
                        if (!recordActions.Contains(action))
                        {
                            recordActions.Add(action);
                        }

                        //
                        autoIds.Add(autoId);
                    }
                }
            }

            return autoIds;
        }

        public List<string> GetIdsFromSearch(SearchInquiry searchInquiry, string idField, List<string> idsIgnored, out List<string> recordActions)
        {
            recordActions = new();
            List<string> autoIds = new();

            if (searchInquiry != null)
            {
                searchInquiry.IsExport = 1;
                var ds = _searchHelper.Inquiry(searchInquiry, int.MaxValue, out _, out _, out _, out _);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    bool isIdExisted = ds.Tables[0].Columns.Contains(idField);
                    bool isActionExisted = ds.Tables[0].Columns.Contains("ACTION");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var dr = ds.Tables[0].Rows[i];

                        var id = isIdExisted ? Convert.ToString(dr[idField]) : string.Empty;
                        if (idsIgnored?.Any(x => x == id) == true)
                            continue;

                        //
                        var action = isActionExisted ? Convert.ToString(dr["ACTION"]) ?? string.Empty : string.Empty;
                        if (!recordActions.Contains(action))
                        {
                            recordActions.Add(action);
                        }

                        //
                        autoIds.Add(id);
                    }
                }
            }

            return autoIds;
        }
    }
}
