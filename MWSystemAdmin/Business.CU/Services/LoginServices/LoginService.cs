using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Core.BLs.LoginBLs;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly ILoginBL _loginBL;
        private readonly IDbManagement DbManagement;

        public LoginService(IMasterDataBaseBL<MWUser> masterDataBaseDA, IDbManagement dbManagement, ILoginBL loginBL)
        {
            _loginBL = loginBL;
            DbManagement = dbManagement;
        }


        public MWUser GetUserByUserName(string userName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            return _loginBL.GetUserByUserName(userName, transaction);
        }

        public List<MWUserFunction> GetFunctionByUserName(string userName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            return _loginBL.GetFunctionByUserName(userName, transaction);
        }


        public async Task<MWUser> GetUserByUserNameAsync(string userName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            return await _loginBL.GetUserByUserNameAsync(transaction, userName);
        }

        public async Task<List<MWUserFunction>> GetFunctionByUserNameAsync(string userName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            return await _loginBL.GetFunctionByUserNameAsync(transaction, userName);
        }
    }
}
