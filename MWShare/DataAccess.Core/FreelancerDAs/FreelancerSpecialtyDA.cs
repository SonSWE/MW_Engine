using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerSpecialtyDA : BaseDA<MWFreelancerSpecialty>, IFreelancerSpecialtyDA
    {
        public FreelancerSpecialtyDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
