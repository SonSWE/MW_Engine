using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using Object;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobDA : BaseDA<MWJob>, IJobDA
    {
        public JobDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
