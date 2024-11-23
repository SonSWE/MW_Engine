using CommonLib;
using CommonLib.Constants;
using CommonLib.Extensions;
using Dapper;
using DataAccess.Core.Interfaces;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using DataAccess.Helpers;
using DataAccess.Core.Helpers;
using DataAccess.Core.Extensions;
using Dapper.Oracle;

namespace DataAccess.Core
{
    public sealed class SearchDA : ISearchDA
    {
        private readonly string _paramPrefix = ":";
        private readonly string _rangeValueSeparator = "|";
        private readonly string _dbDateFormat = "dd-MMM-yyyy";
        private readonly string _conditionsVariable = "{conds}";
        private readonly string _totalRecordField = "TOTAL___RECORD";
        private readonly IDbManagement _dbManagement;
        private readonly ILoggingManagement _loggingManagement;

        public SearchDA(IDbManagement dbManagement, ILoggingManagement loggingManagement)
        {
            _dbManagement = dbManagement;
            _loggingManagement = loggingManagement;
        }
        private IDbConnection _dbConnection => _dbManagement.GetConnection();
        private string _requestId => _loggingManagement.RequestId;


        //
        readonly List<string> strings = new();

        public List<Search> GetAll()
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start.");

            using var connection = _dbConnection;

            var searches = connection.Get<Search>(new { deleted = 0 })?.ToList();

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return searches;
        }

        public List<SearchFld> SearchFldGetAll()
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start.");

            using var connection = _dbConnection;

            var searchFlds = connection.Get<SearchFld>()?.ToList();

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return searchFlds;
        }

        public List<SearchFilterOption> GetSearchFilterOptions(string sqlCmd)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. sqlCmd=[{sqlCmd}]");

            List<SearchFilterOption> searchFilterOptions = null;
            if (!string.IsNullOrEmpty(sqlCmd?.Trim()))
            {
                using var connection = _dbConnection;

                searchFilterOptions = connection.Query<SearchFilterOption>(sqlCmd)?.ToList();
            }

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return searchFilterOptions;
        }

        //
        public DataSet Inquiry(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount)
        {
            DateTime requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. storeName=[{storeName}] searchConds=[{string.Join(",", searchConds?.Select(x => $"{x?.Key}|{x?.Operator}|{x?.DataType}|{x?.Value}").ToList() ?? strings)}] sortConds=[{string.Join(",", sortConds ?? strings)}] fromRecord=[{fromRecord}] toRecord=[{toRecord}]");

            recordCount = 0;
            DataSet ds = null;

            if (!string.IsNullOrEmpty(storeName))
            {
                var oraParams = new OracleDynamicParameters();
                if (searchConds?.Count > 0)
                {
                    foreach (var searchCond in searchConds)
                    {
                        if (searchCond == null || string.IsNullOrEmpty(searchCond.Key))
                        {
                            continue;
                        }

                        oraParams.Add($"p_{searchCond.Key.ToLower()}", $"{searchCond.Operator}|{searchCond.DataType}|{searchCond.Value}", OracleMappingType.Varchar2, ParameterDirection.Input);
                    }
                }

                oraParams.Add("p_language", language, OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_fromrecord", fromRecord, OracleMappingType.Int32, ParameterDirection.Input);
                oraParams.Add("p_torecord", toRecord, OracleMappingType.Int32, ParameterDirection.Input);
                oraParams.Add("p_sortconds", (string.Join(",", sortConds ?? strings) ?? string.Empty), OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_recordcount", 0, OracleMappingType.Int32, ParameterDirection.Output);
                oraParams.Add("p_cursor", null, OracleMappingType.RefCursor, ParameterDirection.Output);


                //
                using var connection = _dbConnection;

                using var reader = connection.ExecuteReader(storeName, oraParams, commandType: CommandType.StoredProcedure);

                var dt = new DataTable();
                dt.Load(reader);

                ds = new DataSet();
                ds.Tables.Add(dt);

                recordCount = oraParams.Get<int>("p_recordcount");
            }

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return ds;
        }

        public DataSet InquiryArray(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, out int recordCount)
        {
            DateTime requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. storeName=[{storeName}] searchConds=[{string.Join(",", searchConds?.Select(x => $"{x?.Key}|{x?.Operator}|{x?.DataType}|{x?.Value}").ToList() ?? strings)}] sortConds=[{string.Join(",", sortConds ?? strings)}] fromRecord=[{fromRecord}] toRecord=[{toRecord}]");

            recordCount = 0;
            DataSet ds = null;
            if (!string.IsNullOrEmpty(storeName))
            {
                string[] condArray = searchConds?.Where(x => x != null && !string.IsNullOrEmpty(x.Key)).Select(x => $"{x.Key}|{x.Operator}|{x.DataType}|{x.Value}").ToArray();

                var oraParams = new OracleDynamicParameters();
                oraParams.Add("p_condarray", (condArray ?? Array.Empty<string>()), OracleMappingType.Varchar2, ParameterDirection.Input, collectionType: OracleMappingCollectionType.PLSQLAssociativeArray, size: (condArray?.Length ?? 0));
                oraParams.Add("p_language", language, OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_fromrecord", fromRecord, OracleMappingType.Int32, ParameterDirection.Input);
                oraParams.Add("p_torecord", toRecord, OracleMappingType.Int32, ParameterDirection.Input);
                oraParams.Add("p_sortconds", (string.Join(",", sortConds ?? strings) ?? string.Empty), OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_recordcount", 0, OracleMappingType.Int32, ParameterDirection.Output);
                oraParams.Add("p_cursor", null, OracleMappingType.RefCursor, ParameterDirection.Output);

                //
                using var connection = _dbConnection;

                using var reader = connection.ExecuteReader(storeName, oraParams, commandType: CommandType.StoredProcedure);

                var dt = new DataTable();
                dt.Load(reader);

                ds = new DataSet();
                ds.Tables.Add(dt);
            }

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return ds;
        }

        public DataSet InquiryOptimize(string storeName, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId)
        {
            realRecordCount = 0;
            maxAutoId = 0;

            DateTime requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. storeName=[{storeName}] searchConds=[{string.Join(",", searchConds?.Select(x => $"{x?.Key}|{x?.Operator}|{x?.DataType}|{x?.Value}").ToList() ?? strings)}] sortConds=[{string.Join(",", sortConds ?? strings)}] maxRecordShow=[{maxRecordShow}]");

            DataSet ds = null;
            if (!string.IsNullOrEmpty(storeName))
            {
                string[] condArray = searchConds?.Where(x => x != null && !string.IsNullOrEmpty(x.Key)).Select(x => $"{x.Key}|{x.Operator}|{x.DataType}|{x.Value}").ToArray();

                var oraParams = new OracleDynamicParameters();
                oraParams.Add("p_condarray", (condArray ?? Array.Empty<string>()), OracleMappingType.Varchar2, ParameterDirection.Input, collectionType: OracleMappingCollectionType.PLSQLAssociativeArray, size: (condArray?.Length ?? 0));
                oraParams.Add("p_language", language, OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_sortconds", (string.Join(",", sortConds ?? strings) ?? string.Empty), OracleMappingType.Varchar2, ParameterDirection.Input);
                oraParams.Add("p_maxrecordshow", maxRecordShow, OracleMappingType.Decimal, ParameterDirection.Input);
                oraParams.Add("p_cursor", null, OracleMappingType.RefCursor, ParameterDirection.Output);

                //
                using var connection = _dbConnection;

                using var reader = connection.ExecuteReader(storeName, oraParams, commandType: CommandType.StoredProcedure);

                var dt = new DataTable();
                dt.Load(reader);

                ds = new DataSet();
                ds.Tables.Add(dt);

                if (ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Columns.Contains("TOTAL___RECORD"))
                        _ = int.TryParse(ds.Tables[0].Rows[0]["TOTAL___RECORD"]?.ToString(), out realRecordCount);
                    //
                    if (ds.Tables[0].Columns.Contains("MAX___AUTOID"))
                        _ = long.TryParse(ds.Tables[0].Rows[0]["MAX___AUTOID"]?.ToString(), out maxAutoId);
                }
            }

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return ds;
        }

        public DataSet InquiryUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int maxRecordShow, out int realRecordCount, out long maxAutoId)
        {
            realRecordCount = 0;
            maxAutoId = 0;

            DateTime requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. searchConds=[{string.Join(",", searchConds?.Select(x => $"{x?.Key}|{x?.Operator}|{x?.DataType}|{x?.Value}").ToList() ?? strings)}] sortConds=[{string.Join(",", sortConds ?? strings)}] maxRecordShow=[{maxRecordShow}]");

            string conds = BuildSearchConds(searchConds, out var dbParams);

            var dicParams = dbParams as IDictionary<string, object>;
            dicParams["language"] = language;

            string selectTotalRows = sqlText?.Contains(_totalRecordField, StringComparison.OrdinalIgnoreCase) == true ? "" : $" COUNT(*) over () AS {_totalRecordField}, ";

            string selectSqlText = sqlText?.Contains(_conditionsVariable) == true
                ? $"SELECT {selectTotalRows} a.* FROM ({(new { conds }).HanselFormat(sqlText)}) a"
                : $"SELECT {selectTotalRows} a.* FROM ({sqlText}) a WHERE 1=1 {conds}";

            string executeSqlText = $@"
                SELECT ROWNUM AS no, a.* FROM (
                    {selectSqlText} 
                    {(sortConds?.Count > 0 ? $"ORDER BY {string.Join(",", sortConds)}" : "")} 
                    FETCH FIRST {maxRecordShow} ROWS ONLY
                ) a";

            using var connection = _dbConnection;
            using var reader = connection.ExecuteReader(executeSqlText, dbParams);

            DataTable dt = new();
            dt.Load(reader);

            if (dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains(_totalRecordField))
                    _ = int.TryParse(dt.Rows[0][_totalRecordField]?.ToString(), out realRecordCount);
                //
                if (dt.Columns.Contains("MAX___AUTOID"))
                    _ = long.TryParse(dt.Rows[0]["MAX___AUTOID"]?.ToString(), out maxAutoId);
            }

            var ds = new DataSet();
            ds.Tables.Add(dt);

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return ds;
        }

        public DataSet InquiryPageUseSqlText(string sqlText, List<SearchInquiryCond> searchConds, List<string> sortConds, string language, int fromRecord, int toRecord, int maxRecordShow, out int recordCount)
        {
            recordCount = 0;

            DateTime requestTime = DateTime.Now;
            Logger.log.Info($"[{_requestId}] Start. searchConds=[{string.Join(",", searchConds?.Select(x => $"{x?.Key}|{x?.Operator}|{x?.DataType}|{x?.Value}").ToList() ?? strings)}] sortConds=[{string.Join(",", sortConds ?? strings)}] fromRecord=[{fromRecord}] toRecord=[{toRecord}] maxRecordShow=[{maxRecordShow}]");

            string conds = BuildSearchConds(searchConds, out var dbParams);

            var dicParams = dbParams as IDictionary<string, object>;
            dicParams["language"] = language;

            string selectTotalRows = sqlText?.Contains(_totalRecordField, StringComparison.OrdinalIgnoreCase) == true ? "" : $" COUNT(*) over () AS {_totalRecordField}, ";

            string selectSqlText = sqlText?.Contains(_conditionsVariable) == true
                ? $"SELECT {selectTotalRows} a.* FROM ({(new { conds }).HanselFormat(sqlText)}) a"
                : $"SELECT {selectTotalRows} a.* FROM ({sqlText}) a WHERE 1=1 {conds}";

            string executeSqlText = $@"
                SELECT aa.* FROM (
                    SELECT ROWNUM AS no, a.* FROM (
                        {selectSqlText} 
                        {(sortConds?.Count > 0 ? $"ORDER BY {string.Join(",", sortConds)}" : "")} 
                    ) a
                ) aa {(fromRecord > 0 && toRecord > 0 ? $" WHERE aa.no BETWEEN {fromRecord} AND {toRecord}" : "")}
            ";

            using var connection = _dbConnection;
            using var reader = connection.ExecuteReader(executeSqlText, dbParams);

            DataTable dt = new();
            dt.Load(reader);

            if (dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains(_totalRecordField))
                    _ = int.TryParse(dt.Rows[0][_totalRecordField]?.ToString(), out recordCount);
            }

            var ds = new DataSet();
            ds.Tables.Add(dt);

            Logger.log.Info($"[{_requestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

            return ds;
        }


        #region Dapper Search

        private string BuildSearchConds(List<SearchInquiryCond> searchConds, out ExpandoObject dbParams)
        {
            //dbParams = null;

            dbParams = new ExpandoObject();
            if (searchConds == null || searchConds.Count == 0)
            {
                return string.Empty;
            }

            //
            string[] dateDataTypes = { Const.Search.DataType.Date, Const.Search.DataType.Date10, Const.Search.DataType.Date16, Const.Search.DataType.Date19, Const.Search.DataType.Date23 };
            var sb = new StringBuilder();
            //dbParams = new ExpandoObject();
            var dicParam = dbParams as IDictionary<string, object>;

            foreach (var item in searchConds)
            {
                if (string.IsNullOrEmpty(item.Operator) || (string.IsNullOrEmpty(item.Value) && !Const.Search.UserRightParam.IsValid(item.Key)))
                {
                    continue;
                }

                string columnName = item.Key;
                string _key = item.Key;
                string _keyTo = item.Key + "_2";
                string paramName = $"{_paramPrefix}{_key}";
                string paramNameTo = $"{_paramPrefix}{_keyTo}";
                string value = item.Value;
                string valueTo = string.Empty;

                bool isDouble_Range = string.Equals(item.Control, Const.Search.Control.Double_Range, StringComparison.OrdinalIgnoreCase);
                bool isLong_Range = string.Equals(item.Control, Const.Search.Control.Long_Range, StringComparison.OrdinalIgnoreCase);
                bool isDate_Range = string.Equals(item.Control, Const.Search.Control.Date_Range, StringComparison.OrdinalIgnoreCase);

                // Get params/cond value
                if (Const.Search.DataType.IsDateDataType(item.DataType))
                {
                    columnName = $"TRUNC({item.Key})";
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        if (ParseDateCond(item.Value, out var dateValue))
                        {
                            value = dateValue.ToString(_dbDateFormat);
                        }
                    }
                }

                if ((isDouble_Range || isLong_Range) && !string.IsNullOrEmpty(item.Value) && item.Value.Contains(_rangeValueSeparator))
                {
                    var parts = item.Value.Split(_rangeValueSeparator);

                    if (decimal.TryParse(parts[0], NumberStyles.None, CultureInfo.InvariantCulture, out var decValueFrom))
                    {
                        value = decValueFrom.ToString();
                    }

                    if (decimal.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out var decValueTo))
                    {
                        valueTo = decValueTo.ToString();
                    }
                }
                else if (isDate_Range && !string.IsNullOrEmpty(item.Value) && item.Value.Contains(_rangeValueSeparator))
                {
                    var parts = item.Value.Split(_rangeValueSeparator);

                    if (ParseDateCond(parts[0], out var dateValueFrom))
                    {
                        value = dateValueFrom.ToString(_dbDateFormat);
                    }

                    if (ParseDateCond(parts[1], out var dateValueTo))
                    {
                        valueTo = dateValueTo.ToString(_dbDateFormat);
                    }
                }

                // Add cond value
                dicParam.TryAdd(_key, value);
                if (isDouble_Range || isDate_Range)
                {
                    dicParam.TryAdd(_keyTo, valueTo);
                }

                // Build sql text
                if (isDouble_Range || isDate_Range)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        sb.Append($" AND {columnName} >= {paramName} ");
                    }

                    if (!string.IsNullOrEmpty(valueTo))
                    {
                        sb.Append($" AND {columnName} <= {paramNameTo} ");
                    }
                }
                else if (string.Equals(item.Operator, Const.Search.Operator.Like, StringComparison.OrdinalIgnoreCase))
                {
                    sb.Append($" AND UPPER({columnName}) LIKE '%' || UPPER({paramName}) || '%' ");
                }
                else if (string.Equals(item.Operator, Const.Search.Operator.Equal, StringComparison.OrdinalIgnoreCase)
                    && (string.IsNullOrEmpty(item.DataType) || string.Equals(item.DataType, Const.Search.DataType.String, StringComparison.OrdinalIgnoreCase)))
                {
                    if (!string.IsNullOrEmpty(value) && value.Contains('*'))
                    {
                        sb.Append($" AND UPPER({columnName}) LIKE UPPER(REPLACE({paramName}, '*', '%')) ");
                    }
                    else
                    {
                        sb.Append($" AND UPPER({columnName}) = UPPER({paramName}) ");
                    }
                }
                else if (string.Equals(item.Operator, Const.Search.Operator.In, StringComparison.OrdinalIgnoreCase))
                {
                    //sb.Append($" AND fn_check_contain_list({paramName}, {columnName}) > 0 ");

                    sb.Append($" AND {columnName} IN {paramName} ");
                    
                    // Chuyển đổi chuỗi điều kiện val1,val2,... => array [val1, val2, ...]
                    if (dicParam.TryGetValue(_key, out var existedValue))
                    {
                        dicParam.Remove(_key);
                        dicParam.TryAdd(_key, existedValue?.ToString()?.Split(",").ToList() ?? new() { "" });
                    }
                }
                else
                {
                    sb.Append($" AND {columnName} {item.Operator} {paramName} ");
                }
            }

            return sb.ToString();
        }

        private bool ParseDateCond(string value, out DateTime date)
        {
            if (DateTime.TryParseExact(value, Const.DateFormat.yyyyMMdd_Hyphens, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return true;
            }
            else if (DateTime.TryParseExact(value, Const.DateFormat.yyyyMMdd, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
