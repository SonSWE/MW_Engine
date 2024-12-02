using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;


namespace DataAccess.Core.JobDAs
{
    public sealed class ProposalDA : BaseDA<MWProposal>, IProposalDA
    {
        public ProposalDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
