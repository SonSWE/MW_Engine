using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.FreelancerServices
{
    public interface IFreelancerService
    {
        long UpdateIsOpenForJob(MWFreelancer data, ClientInfo clientInfo, out string createResMessage);
    }
}
