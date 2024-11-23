using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using DataAccess.Helpers;
using System;
using System.Data;

namespace DataAccess.Core.SystemDAs
{
    public sealed class CommonDA : ICommonDA
    {
        private readonly IDbManagement _dbManagement;
        private readonly ILoggingManagement _loggingManagement;

        public CommonDA(IDbManagement dbManagement, ILoggingManagement loggingManagement)
        {
            _dbManagement = dbManagement;
            _loggingManagement = loggingManagement;
        }

        private IDbConnection _dbConnection => _dbManagement.GetConnection();
        private string _requestId => _loggingManagement.RequestId;

        public string GetBusDate()
        {
            using var connection = _dbConnection;

            var date = connection.QueryFirstOrDefault<DateTime>("SELECT f_currdate FROM DUAL");

            return date.ToString(Const.DateFormat.ddMMyyyy_Slash);
        }

        public bool IsWorkingDate(DateTime date)
        {
            using var connection = _dbConnection;

            var isWorkingDate = connection.QueryFirstOrDefault<int>("SELECT fn_isworkingdate(:date) FROM DUAL", new { date });

            return isWorkingDate > 0;
        }

        public string GetTxNum(long branchId)
        {
            using var connection = _dbConnection;

            var txNum = connection.QueryFirstOrDefault<string>("SELECT fn_gettxnum(:branchId) FROM DUAL", new { branchId });

            return txNum;
        }

        public string[] GetTxNums(long branchId, int numberToGet)
        {
            if (numberToGet <= 0)
            {
                return Array.Empty<string>();
            }

            //
            using var connection = _dbConnection;

            var txNums = new string[numberToGet];
            for (int i = 0; i < numberToGet; i++)
            {
                txNums[i] = connection.QueryFirstOrDefault<string>("SELECT fn_gettxnum(:branchId) FROM DUAL", new { branchId });
            }

            return txNums;
        }

        public DataSet ExecteSqlCmdToDataSet(string sqlCmd)
        {
            using var connection = _dbConnection;
            using var reader = connection.ExecuteReader(sqlCmd);

            DataTable dt = new();
            dt.Load(reader);

            var ds = new DataSet();
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
