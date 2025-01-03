using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.ClientBLs;
using Business.Core.BLs.SysParamBLs;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Validators;
using CommonLib.Constants;
using DataAccess.Core.ClientDAs;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using DataAccess.Core.WalletDAs;
using FluentValidation;
using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Business.Core.Services.ClientServices
{
    public class ClientService : MasterDataBaseService<MWClient>, IClientService
    {
        private readonly IMasterDataBaseBL<MWUser> _userBL;
        private readonly IUserBL _userBLA;
        private readonly IMasterDataBaseBL<MWWallet> _walletBL;
        private readonly IWalletDA _walletDA;


        public override string ProfileKeyField => Const.ProfileKeyField.Client;

        public ClientService(IMasterDataBaseBL<MWClient> masterDataBaseDA, IDbManagement dbManagement, IMasterDataBaseBL<MWUser> userBL, IMasterDataBaseBL<MWWallet> walletBL,
            IWalletDA walletDA, IUserBL userBLA) : base(masterDataBaseDA, dbManagement)
        {
            _userBL = userBL;
            _walletBL = walletBL;
            _walletDA = walletDA;
            _userBLA = userBLA;
        }

        public override BaseValidator<MWClient> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWClient dataToValidate, MWClient oldData)
        {
            return new ClientValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public override bool ValidateCreate(IDbTransaction transaction, MWClient data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {

            resCode = 0;
            resMessage = string.Empty;

            if (string.IsNullOrEmpty(data.Email))
            {
                resMessage = "Email không dược bỏ trống";
                resCode = -100013;
                return false;
            }

            if (_userBLA.IsExistedUserName(transaction, data.Email))
            {
                resMessage = "Email đã tồn tại trong hệ thống";
                resCode = -100014;
                return false;
            }

            return true;
        }
        public override void BeforeCreate(IDbTransaction transaction, MWClient data)
        {
            data.Status = Const.Client_Status.Active;
        }
        public override bool OnCreated(IDbTransaction transaction, MWClient data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            resCode = 0;
            resMessage = string.Empty;

            var user = _userBL.GetDetailById(transaction, data.Email);

            if (user == null)
            {
                //nếu chưa có tài khoản thì tạo tài khoản tự động
                MWUser userData = new MWUser();
                userData.UserName = data.Email;
                userData.Password = data.Password;
                userData.Avatar = data.Avatar;
                //pass

                userData.Name = data.Name;
                userData.UserType = Const.USER_TYPE.User;
                userData.LoginType = Const.LOGIN_TYPE.Client;
                userData.LoggedClientId = data.ClientId;
                //mặc định k được phép đăng nhập, sau khi xác thực email mới được phép đăng nhập
                userData.EnableLogon = Const.YN.Yes;
                userData.Status = Const.User_Status.Active;
                ////yêu cầu đổi mật khẩu với lần đầu đăng nhập
                //userData.MustChangePasswordAtNextLogonText = Const.YN.Yes;

                //định danh
                userData.IdentityCard = data.IdentityCard;
                userData.IdentityAddress = data.IdentityAddress;
                userData.IdentityIssueDate = data.IdentityIssueDate;
                userData.IdentityExpirationDate = data.IdentityExpirationDate;

                userData.CreateDate = DateTime.Now;
                userData.CreateBy = clientInfo.UserName;
                //phân quyền mặc định cho freelancer

                var result = _userBL.Insert(transaction, userData, clientInfo);

                if (result < 0)
                {
                    resCode = result;
                    return false;
                }
            }

            //tạo ví tự động
            var wallet = _walletDA.GetViewFirstOrDefault(new Dictionary<string, object>
            {
                { nameof(MWWallet.UserName),data.Email},
            }, transaction);

            if (wallet == null)
            {
                //nếu chưa có tài khoản thì tạo tài khoản tự động
                MWWallet newWallet = new MWWallet();
                newWallet.UserName = data.Email;
                newWallet.Balance = 0;
                newWallet.Status = Const.Wallet_Status.Inactive;

                var result = _walletBL.Insert(transaction, newWallet, clientInfo);

                if (result < 0)
                {
                    resCode = result;
                    return false;
                }
            }


            return true;
        }
    }
}
