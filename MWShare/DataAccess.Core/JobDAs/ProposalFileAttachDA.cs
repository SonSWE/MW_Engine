using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using Object;

namespace DataAccess.Core.JobDAs
{
    public sealed class ProposalFileAttachDA : BaseDA<MWProposalFileAttach>, IProposalFileAttachDA
    {
        public ProposalFileAttachDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
