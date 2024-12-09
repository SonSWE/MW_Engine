using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobDA : BaseDA<MWJob>, IJobDA
    {
        public JobDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public long GetNextSequenceValue(IDbTransaction transaction)
        {
            string sqlText = $"SELECT seq_{Const.DbTable.MWJob}.NEXTVAL FROM dual";
            long result = transaction.Connection.QueryFirstOrDefault<long>(sqlText);
            return result;
        }
    }
}
