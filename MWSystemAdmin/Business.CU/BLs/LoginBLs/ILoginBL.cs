using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.LoginBLs
{
    public interface ILoginBL
    {
        MWUser GetUserByUserName(string userName, IDbTransaction transaction);
        List<MWUserFunction> GetFunctionByUserName(string userName, IDbTransaction transaction);

        Task<MWUser> GetUserByUserNameAsync(IDbTransaction transaction, string userName);
        Task<List<MWUserFunction>> GetFunctionByUserNameAsync(IDbTransaction transaction, string userName);
    }
}
