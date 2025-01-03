using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.FreelancerBLs
{
    public interface IFreelancerBL
    {
        MWFreelancer GetDetailByEmail(IDbTransaction transaction, string email);
        bool IsExistedEmail(IDbTransaction transaction, string email, string freelancerId);
    }
}
