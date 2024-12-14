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
using Business.Core.BLs.BaseBLs;
using DataAccess.Core.JobDAs;
using Object;
using DataAccess.Core.FileAttachDAs;
using DataAccess.Core.ClientDAs;
using System.Collections.Generic;
using DataAccess.Core.UserDAs;

namespace Business.Core.BLs.ClientBLs
{
    public class ClientBL : MasterDataBaseBL<MWClient>, IClientBL
    {
        private readonly IMasterDataBaseBL<MWUser> _userBL;
        private readonly IUserDA _userDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Client;
        public override string DbTable => Const.DbTable.MWClient;

        public ClientBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IMasterDataBaseBL<MWUser> userBL, IUserDA userDA) : base(dbManagement, loggingManagement)
        {
            _userBL = userBL;
            _userDA = userDA;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWClient data)
        {
            //tự sinh id
            data.ClientId = "CL" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }

        public override long InsertData(IDbTransaction transaction, MWClient data, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;


            var user = _userDA.GetFirstOrDefault(new Dictionary<string, object>()
            {
                { nameof(MWUser.UserName), data.Email }
            });

            if (user == null)
            {
                //nếu chưa có tài khoản thì tạo tài khoản tự động
                MWUser userData = new MWUser();
                userData.UserName = data.Email;
                userData.Email = data.Email;
                //pass
                userData.Password = data.Password;
                userData.Name = data.Name;
                userData.UserType = Const.USER_TYPE.User;
                userData.LoginType = Const.LOGIN_TYPE.Client;
                //mặc định k được phép đăng nhập, sau khi xác thực email mới được phép đăng nhập
                userData.EnableLogon = Const.YN.No;
                userData.Status = Const.User_Status.PendingVerify;
                ////yêu cầu đổi mật khẩu với lần đầu đăng nhập
                //userData.MustChangePasswordAtNextLogonText = Const.YN.Yes;
                userData.CreateDate = data.CreateDate;
                userData.CreateBy = data.CreateBy;

                //phân quyền mặc định cho freelancer

                resultValues = _userBL.Insert(transaction, userData, clientInfo);
            }

            if (resultValues > 0)
            {
                resultValues = base.InsertData(transaction, data, clientInfo);
            }

            return resultValues;
        }
    }
}
