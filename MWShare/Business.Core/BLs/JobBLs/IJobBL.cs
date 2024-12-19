using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.JobBLs
{
    public interface IJobBL
    {
        List<MWJob> GetSuggestByFreelancer(IDbTransaction transaction, string freelancerId);
        List<MWJob> GetByClientId(IDbTransaction transaction, string clientId);
    }
}
