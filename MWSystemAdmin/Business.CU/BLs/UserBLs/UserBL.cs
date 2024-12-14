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
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.ClientDAs;

namespace Business.Core.BLs.UserBLs
{
    public class UserBL : MasterDataBaseBL<MWUser>, IUserBL
    {
        private readonly IUserDA _userDA;
        private readonly IUserFunctionDA _userFunctionDA;
        private readonly IFreelancerDA _freelancerDA;
        private readonly IClientDA _clientDA;
        public override string ProfileKeyField => Const.ProfileKeyField.User;
        public override string DbTable => Const.DbTable.MWUser;

        public UserBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IUserDA userDA, IUserFunctionDA userFunctionDA,
            IFreelancerDA freelancerDA, IClientDA clientDA) : base(dbManagement, loggingManagement)
        {
            _userDA = userDA;
            _userFunctionDA = userFunctionDA;
            _freelancerDA = freelancerDA;
            _clientDA = clientDA;
        }

        public override MWUser GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWUser data = base.GetDetailById(transaction, id);
            if (data != null && !string.IsNullOrEmpty(data.Email))
            {
                data.Clients = _clientDA.GetView(new
                {
                    data.Email,
                }, transaction).ToList() ?? new();

                data.Freelancer = _freelancerDA.GetView(new
                {
                    data.Email,
                }, transaction).SingleOrDefault() ?? new();
            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

    }
}
