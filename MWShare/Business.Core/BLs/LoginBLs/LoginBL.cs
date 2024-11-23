using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using DataAccess.Core.SystemCodeDAs;
using DataAccess.Core.UserDAs;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Core.LoginDAs;
using Dapper;

namespace Business.Core.BLs.LoginBLs
{
    public class LoginBL : ILoginBL
    {
        private readonly ILoginDA _loginDA;


        public LoginBL(ILoginDA loginDA)
        {
            _loginDA = loginDA;


        }

        public MWUser GetUserByUserName(string userName, IDbTransaction transaction)
        {
            return _loginDA.GetUserByUserName(transaction, userName);
        }

        public List<MWUserFunction> GetFunctionByUserName(string userName, IDbTransaction transaction)
        {
            return _loginDA.GetFunctionByUserName(transaction, userName);
        }

        public async Task<MWUser> GetUserByUserNameAsync(IDbTransaction transaction, string userName)
        {
            return await _loginDA.GetUserByUserNameAsync(transaction, userName);
        }

        public async Task<List<MWUserFunction>> GetFunctionByUserNameAsync(IDbTransaction transaction, string userName)
        {
            return await _loginDA.GetFunctionByUserNameAsync(transaction, userName);
        }

    }
}
