using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.JobBLs
{
    public interface IJobSavedBL
    {
        long InsertData(IDbTransaction transaction, MWJobSaved data);
        long DeleteData(IDbTransaction transaction, MWJobSaved data);
        List<MWJob> GetSavedJobsByFreelancer(IDbTransaction transaction, string freelancerId);
    }
}
