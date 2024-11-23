using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using DataAccess.Core.SkillDAs;
using Object;

namespace DataAccess.Core.JobDAs
{
    public sealed class CategoryDA : BaseDA<MWCategory>, ICategoryDA
    {
        public CategoryDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
