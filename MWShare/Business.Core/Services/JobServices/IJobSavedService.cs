using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.JobServices
{
    public interface IJobSavedService
    {
        List<MWJob> GetSavedJobsByFreelancer(string freelancerId, ClientInfo clientInfo);
        long InsertData(MWJobSaved data, ClientInfo clientInfo, out string createResMessage);
        long DeleteData(MWJobSaved data, ClientInfo clientInfo, out string createResMessage);

    }
}
