using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using Object;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobFileAttachDA : BaseDA<MWJobFileAttach>, IJobFileAttachDA
    {
        public JobFileAttachDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
