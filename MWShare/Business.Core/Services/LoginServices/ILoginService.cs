using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.LoginServices
{
    public interface ILoginService
    {
        MWUser GetUserByUserName(string userName);
        List<MWUserFunction> GetFunctionByUserName(string userName);
        Task<MWUser> GetUserByUserNameAsync(string userName);
        Task<List<MWUserFunction>> GetFunctionByUserNameAsync(string userName);

    }
}
