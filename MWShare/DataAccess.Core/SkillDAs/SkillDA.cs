using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;

namespace DataAccess.Core.SkillDAs
{
    public sealed class SkillDA : BaseDA<MWSkill>, ISkillDA
    {
        public SkillDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public long GetNextSequenceValue(IDbTransaction transaction)
        {
            string sqlText = $"SELECT {Const.SeqTable.skill}.NEXTVAL FROM dual";
            long result = transaction.Connection.QueryFirstOrDefault<long>(sqlText);
            return result;
        }
    }
}
