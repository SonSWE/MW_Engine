using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.FreelancerDAs
{
    public interface IFreelancerDA : IBaseDA<MWFreelancer>
    {
        int UpdateIsOpenForJob(MWFreelancer data, IDbTransaction transaction);
        int UpdateHourlyRate(MWFreelancer data, IDbTransaction transaction);
        int UpdateHourWorkingPerWeek(MWFreelancer data, IDbTransaction transaction);
        int UpdateTitle(MWFreelancer data, IDbTransaction transaction);
        int UpdateBio(MWFreelancer data, IDbTransaction transaction);
    }
}
