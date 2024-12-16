using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.FreelancerDAs
{
    public interface IFreelancerDA : IBaseDA<MWFreelancer>
    {
        int UpdateIsOpenForJob(MWFreelancer data, IDbTransaction transaction);
    }
}
