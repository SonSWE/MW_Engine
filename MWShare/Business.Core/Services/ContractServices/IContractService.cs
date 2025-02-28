using Object;
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
        List<MWContractResult> GetContractResultByContractId(string contractId);
        long SendOffer(MWContract data, ClientInfo clientInfo, out string resMessage, out string propertyName);
        long PaymentContract(string id, ClientInfo clientInfo, out string resMessage);
        long SubmitContractResult(MWContractResult data, ClientInfo clientInfo, out string resMessage);
        long DoneContract(MWFeedBack data, ClientInfo clientInfo, out string resMessage);
        long EndContract(MWContract data, ClientInfo clientInfo, out string resMessage);
        long ApprovalContractComplaint(string id, string status, ClientInfo clientInfo, out string resMessage);

        Task<List<string>> GetContractIdsEndDate();

        Task<MWContract> GetDetailByIdAync(string id);
    }
}
