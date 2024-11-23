using Dapper;
using DapperLib;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Core.UserDAs
{
    public sealed class UserFunctionDA : BaseDA<MWUserFunction>, IUserFunctionDA
    {
        public UserFunctionDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
