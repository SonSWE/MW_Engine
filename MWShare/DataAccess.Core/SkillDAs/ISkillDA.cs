using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.SkillDAs
{
    public interface ISkillDA : IBaseDA<MWSkill>
    {
        long GetNextSequenceValue(IDbTransaction transaction);
    }
}
