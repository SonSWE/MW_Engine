using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Core.LoginDAs
{
    public interface ILoginDA
    {
        MWUser GetUserByUserName(IDbTransaction transaction, string userId);
        List<MWUserFunction> GetFunctionByUserName(IDbTransaction transaction, string userName);

        Task<MWUser> GetUserByUserNameAsync(IDbTransaction transaction, string userName);
        Task<List<MWUserFunction>> GetFunctionByUserNameAsync(IDbTransaction transaction, string userName);
    }
}
