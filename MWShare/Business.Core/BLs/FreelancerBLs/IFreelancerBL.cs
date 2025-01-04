using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace Business.Core.BLs.FreelancerBLs
{
    public interface IFreelancerBL
    {
        MWFreelancer GetDetailByEmail(IDbTransaction transaction, string email);
        bool IsExistedEmail(IDbTransaction transaction, string email, string freelancerId);
        long UpdateEducation(IDbTransaction transaction, List<MWFreelancerEducation> data, ClientInfo clientInfo);
        long DeleteEducation(IDbTransaction transaction, MWFreelancerEducation data, ClientInfo clientInfo);
        int UpdateIsOpenForJob(MWFreelancer data, IDbTransaction transaction);
        int UpdateHourlyRate(MWFreelancer data, IDbTransaction transaction);
        int UpdateHourWorkingPerWeek(MWFreelancer data, IDbTransaction transaction);
        int UpdateTitle(MWFreelancer data, IDbTransaction transaction);
        int UpdateBio(MWFreelancer data, IDbTransaction transaction);
    }
}
