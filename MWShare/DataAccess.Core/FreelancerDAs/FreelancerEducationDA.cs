using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerEducationDA : BaseDA<MWFreelancerEducation>, IFreelancerEducationDA
    {
        public FreelancerEducationDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
