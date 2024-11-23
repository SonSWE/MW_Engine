using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;

namespace DataAccess.Core.DefErrorDAs
{
    public sealed class DefErrorDA : BaseDA<DefError>, IDefErrorDA
    {
        public DefErrorDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
