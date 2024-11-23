using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using Object;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobSkillDA : BaseDA<MWJobSkill>, IJobSkillDA
    {
        public JobSkillDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
