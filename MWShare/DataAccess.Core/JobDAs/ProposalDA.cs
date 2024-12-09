using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;


namespace DataAccess.Core.JobDAs
{
    public sealed class ProposalDA : BaseDA<MWProposal>, IProposalDA
    {
        public ProposalDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public long GetNextSequenceValue(IDbTransaction transaction)
        {
            string sqlText = $"SELECT seq_{Const.DbTable.MWProposal}.NEXTVAL FROM dual";
            long result = transaction.Connection.QueryFirstOrDefault<long>(sqlText);
            return result;
        }
    }
}
