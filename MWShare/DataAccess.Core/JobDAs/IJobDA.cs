using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.JobDAs
{
    public interface IJobDA : IBaseDA<MWJob>
    {
        long GetNextSequenceValue(IDbTransaction transaction);
    }
}
