using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Core.JobDAs
{
    public interface IContractDA : IBaseDA<MWContract>
    {
        Task<List<string>> GetContractIdsEndDate();
    }
}
