using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerWorkingHistoryDA : BaseDA<MWFreelancerWorkingHistory>, IFreelancerWorkingHistoryDA
    {
        public FreelancerWorkingHistoryDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
