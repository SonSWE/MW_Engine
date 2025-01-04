using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.JobDAs
{
    public interface IJobDA : IBaseDA<MWJob>
    {
        List<MWJob> GetSuggestByFreelancer(IDbTransaction transaction, string freelancerId);
        List<MWJob> Search(IDbTransaction transaction, SearchJobRequest data);
    }
}
