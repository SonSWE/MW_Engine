using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerSkillDA : BaseDA<MWFreelancerSkill>, IFreelancerSkillDA
    {
        public FreelancerSkillDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
