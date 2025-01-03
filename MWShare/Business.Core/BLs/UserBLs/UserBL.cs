using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Business.Core.BLs.BaseBLs;
using Dapper;
using DataAccess.Core.UserDAs;

namespace Business.Core.BLs.UserBLs
{
    public class UserBL : MasterDataBaseBL<MWUser>, IUserBL
    {
        private readonly IUserDA _userDA;
        public override string ProfileKeyField => Const.ProfileKeyField.User;
        public override string DbTable => Const.DbTable.MWUser;

        public UserBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IUserDA userDA) : base(dbManagement, loggingManagement)
        {

            _userDA = userDA;
        }

        public bool IsExistedUserName(IDbTransaction transaction, string username)
        {
            var count = _baseDA.Count(new Dictionary<string, object> { { nameof(MWUser.UserName), username } }, transaction);
            return count > 0;
        }

        public int UpdateAvatar(MWUser data, IDbTransaction transaction)
        {
            return _userDA.UpdateAvatar(data, transaction);
        }

    }
}
