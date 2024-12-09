using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;

namespace DataAccess.Core.SpencialDAs
{
    public sealed class SpecialtyDA : BaseDA<MWSpecialty>, ISpecialtyDA
    {
        public SpecialtyDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public long GetNextSequenceValue(IDbTransaction transaction)
        {
            string sqlText = $"SELECT seq_{Const.DbTable.MWSpecialty}.NEXTVAL FROM dual";
            long result = transaction.Connection.QueryFirstOrDefault<long>(sqlText);
            return result;
        }
    }
}
