using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.ProposalServices
{
    public interface IProposalService
    {
        List<MWProposal> GetProposalByFreelancer(string freelancerId);
        List<MWProposal> GetProposalByJobId(string jobId);
    }
}
