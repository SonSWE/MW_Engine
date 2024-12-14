using CommonLib.Constants;
using CommonLib.Extensions;
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
using Business.Core.BLs.BaseBLs;

namespace Business.Core.BLs.UserBLs
{
    public class UserFunctionBL : MasterDataBaseBL<MWUserFunction>, IUserFunctionBL
    {
        private readonly IUserFunctionDA _userFunctionDA;
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;
        public override string DbTable => Const.DbTable.MWUser;

        public UserFunctionBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IUserFunctionDA userFunctionDA) : base(dbManagement, loggingManagement)
        {
            _userFunctionDA = userFunctionDA;
        }
    }
}
