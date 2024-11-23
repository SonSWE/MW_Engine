using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.SkillDAs
{
    public sealed class SkillDA : BaseDA<MWSkill>, ISkillDA
    {
        public SkillDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
