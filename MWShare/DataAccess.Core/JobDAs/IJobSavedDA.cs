using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Core.JobDAs
{
    public interface IJobSavedDA : IBaseDA<MWJobSaved>
    {
        int DeleteData(IDbTransaction transaction, MWJobSaved data);
        List<MWJob> GetSavedJobsByFreelancer(IDbTransaction transaction, string freelancerId);
    }
}
