using CommonLib.Constants;
using Dapper;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Core.LoginDAs
{
    public sealed class LoginDA : ILoginDA
    {
        public MWUser GetUserByUserName(IDbTransaction transaction, string userName)
        {
            var user = transaction.Connection.QueryFirstOrDefault<MWUser>(
                $@"SELECT * FROM {Const.DbTable.MWUser} WHERE UPPER({nameof(MWUser.UserName)}) = UPPER(:{nameof(userName)})",
                new { userName },
                transaction
            );

            return user;
        }

        public List<MWUserFunction> GetFunctionByUserName(IDbTransaction transaction, string userName)
        {
            var functions = transaction.Connection.Query<MWUserFunction>(
                $@"SELECT * FROM VW_{Const.DbTable.MWUserFunction} WHERE UPPER({nameof(MWUser.UserName)}) = UPPER(:{nameof(userName)})",
                new { userName },
                transaction
            ).ToList();

            return functions;
        }

        public async Task<MWUser> GetUserByUserNameAsync(IDbTransaction transaction, string userName)
        {
            return await transaction.Connection.QueryFirstOrDefaultAsync<MWUser>(
                $@"SELECT * FROM {Const.DbTable.MWUser} WHERE UPPER({nameof(MWUser.UserName)}) = UPPER(:{nameof(userName)})",
                new { userName },
                transaction
            );
        }

        public async Task<List<MWUserFunction>> GetFunctionByUserNameAsync(IDbTransaction transaction, string userName)
        {

            var functions = (await transaction.Connection.QueryFirstOrDefaultAsync<MWUserFunction>(
                $@"SELECT * FROM VW_{Const.DbTable.MWUserFunction} WHERE UPPER({nameof(MWUser.UserName)}) = UPPER(:{nameof(userName)})",
                new { userName },
                transaction
            )).ToList() ?? new();

            return functions;
        }
    }
}
