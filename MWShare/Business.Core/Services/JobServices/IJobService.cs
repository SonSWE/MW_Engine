using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.JobServices
{
    public interface IJobService
    {
        List<MWJob> GetSuggestByFreelancer(string freelancerId, ClientInfo clientInfo);
        List<MWJob> GetByClientId(string clientId, ClientInfo clientInfo);
    }
}
