using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.JobDAs
{
    public interface IProposalDA : IBaseDA<MWProposal>
    {
        long GetNextSequenceValue(IDbTransaction transaction);
    }
}
