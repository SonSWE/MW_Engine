using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.AccountTalentDAs
{
    public sealed class TalentSkillDA : BaseDA<MWTalentSkill>, ITalentSkillDA
    {
        public TalentSkillDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
