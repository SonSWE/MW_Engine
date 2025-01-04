using Object;
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
        long UpdateAvatar(MWFreelancer data, ClientInfo clientInfo, out string resMessage);
        long UpdateHourlyRate(MWFreelancer data, ClientInfo clientInfo, out string resMessage);
        long UpdateTitle(MWFreelancer data, ClientInfo clientInfo, out string resMessage);
        long UpdateBio(MWFreelancer data, ClientInfo clientInfo, out string resMessage);
        long UpdateHourWorkingPerWeek(MWFreelancer data, ClientInfo clientInfo, out string resMessage);
        long UpdateEducation(List<MWFreelancerEducation> data, ClientInfo clientInfo, out string resMessage);
        long DeleteEducation(MWFreelancerEducation data, ClientInfo clientInfo, out string resMessage);
    }
}
