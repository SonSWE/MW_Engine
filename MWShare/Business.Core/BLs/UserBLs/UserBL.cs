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
using DataAccess.Core.ClientDAs;
using Business.Core.BLs.FreelancerBLs;

namespace Business.Core.BLs.UserBLs
{
    public class UserBL : MasterDataBaseBL<MWUser>, IUserBL
    {
        private readonly IUserFunctionDA _userFunctionDA;
        public override string ProfileKeyField => Const.ProfileKeyField.User;
        public override string DbTable => Const.DbTable.MWUser;

        public UserBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IUserFunctionDA userFunctionDA) : base(dbManagement, loggingManagement)
        {
            _userFunctionDA = userFunctionDA;


        }

        public override MWUser GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWUser data = base.GetDetailById(transaction, id);
            
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

    }
}
