using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerSpecialProjectDA : BaseDA<MWFreelancerSpecialProject>, IFreelancerSpecialProjectDA
    {
        public FreelancerSpecialProjectDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
