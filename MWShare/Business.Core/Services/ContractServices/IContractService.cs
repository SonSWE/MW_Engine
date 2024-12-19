using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.ContractServices
{
    public interface IContractService
    {
        List<MWContract> GetContractByFreelancer(string freelancerId);
        List<MWContract> GetContractByJobId(string jobId);
        long UpdateStatus(string id, string status, string des, ClientInfo clientInfo, out string resMessage, out string propertyName);
        long SubmitContract(MWContract data, ClientInfo clientInfo, out string resMessage, out string propertyName);
    }
}
