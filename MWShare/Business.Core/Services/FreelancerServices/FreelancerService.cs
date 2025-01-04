using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.FreelancerBLs;
using System;
using CommonLib.Extensions;
using System.Linq;
using ZeroMQ;
using DataAccess.Core.FreelancerDAs;
using System.Collections.Generic;
using Object;
using DataAccess.Core.WalletDAs;
using Business.Core.BLs.UserBLs;
using DataAccess.Core.UserDAs;

namespace Business.Core.Services.FreelancerServices
{
    public class FreelancerService : MasterDataBaseService<MWFreelancer>, IFreelancerService
    {
        private readonly IFreelancerBL _freelancerBL;
        private readonly IMasterDataBaseBL<MWUser> _userBLBase;
        private readonly IUserBL _userBL;
        private readonly IMasterDataBaseBL<MWWallet> _walletBL;
        private readonly IWalletDA _walletDA;
        public FreelancerService(IMasterDataBaseBL<MWFreelancer> masterDataBaseDA, IDbManagement dbManagement, IMasterDataBaseBL<MWUser> userBLBase
            , IMasterDataBaseBL<MWWallet> walletBL, IWalletDA walletDA, IUserBL userBL, IFreelancerBL freelancerBL) : base(masterDataBaseDA, dbManagement)
        {
            _userBLBase = userBLBase;
            _walletBL = walletBL;
            _walletDA = walletDA;
            _userBL = userBL;
            _freelancerBL = freelancerBL;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Freelancer;
        public override BaseValidator<MWFreelancer> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWFreelancer dataToValidate, MWFreelancer oldData)
        {
            return new FreelancerValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public override bool ValidateCreate(IDbTransaction transaction, MWFreelancer data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {

            resCode = 0;
            resMessage = string.Empty;

            if (string.IsNullOrEmpty(data.Email))
            {
                resMessage = "Email không dược bỏ trống";
                resCode = -100013;
                return false;
            }

            if (_userBL.IsExistedUserName(transaction, data.Email))
            {
                resMessage = "Email đã tồn tại trong hệ thống";
                resCode = -100014;
                return false;
            }

            return true;
        }
        public override void BeforeCreate(IDbTransaction transaction, MWFreelancer data)
        {
            data.Status = Const.Freelancer_Status.Active;
        }
        public override bool OnCreated(IDbTransaction transaction, MWFreelancer data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            resCode = 0;
            resMessage = string.Empty;

            var user = _userBLBase.GetDetailById(transaction, data.Email);

            if (user == null)
            {
                //nếu chưa có tài khoản thì tạo tài khoản tự động
                MWUser userData = new MWUser();
                userData.UserName = data.Email;
                userData.Password = data.Password;
                //
                userData.PhoneNumber = data.PhoneNumber;
                //pass
                userData.Avatar = data.Avatar;
                userData.Name = data.Name;
                userData.UserType = Const.USER_TYPE.User;
                userData.LoginType = Const.LOGIN_TYPE.Freelancer;
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
                //
                userData.CreateDate = data.CreateDate;
                userData.CreateBy = data.CreateBy;

                //phân quyền mặc định cho freelancer

                var result = _userBLBase.Insert(transaction, userData, clientInfo);

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

        public long UpdateIsOpenForJob(MWFreelancer data, ClientInfo clientInfo, out string createResMessage)
        {
            createResMessage = string.Empty;
            if (data == null || string.IsNullOrEmpty(data.FreelancerId))
            {
                createResMessage = "Dữ liệu không hợp lệ";
                return -1;
            }

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            data.LastChangeBy = clientInfo.UserName;
            data.LastChangeDate = DateTime.Now;

            long result = _freelancerBL.UpdateIsOpenForJob(data, transaction);

            if (result > 0)
            {
                createResMessage = "Cập nhật thành công";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateAvatar(MWFreelancer data, ClientInfo clientInfo, out string resMessage)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            resMessage = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            var userUpdateAVT = new MWUser() { UserName = data.Email, Avatar = data.Avatar, LastChangeBy = clientInfo.UserName, LastChangeDate = DateTime.Now };

            result = _userBL.UpdateAvatar(userUpdateAVT, transaction);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateHourlyRate(MWFreelancer data, ClientInfo clientInfo, out string resMessage)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            resMessage = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            result = _freelancerBL.UpdateHourlyRate(data, transaction);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateTitle(MWFreelancer data, ClientInfo clientInfo, out string resMessage)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            resMessage = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            result = _freelancerBL.UpdateTitle(data, transaction);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateBio(MWFreelancer data, ClientInfo clientInfo, out string resMessage)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            resMessage = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            result = _freelancerBL.UpdateBio(data, transaction);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateHourWorkingPerWeek(MWFreelancer data, ClientInfo clientInfo, out string resMessage)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            resMessage = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            result = _freelancerBL.UpdateHourWorkingPerWeek(data, transaction);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateEducation(List<MWFreelancerEducation> data, ClientInfo clientInfo, out string resMessage)
        {
            long result = ErrorCodes.Success;
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            result = _freelancerBL.UpdateEducation(transaction, data, clientInfo);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long DeleteEducation(MWFreelancerEducation data, ClientInfo clientInfo, out string resMessage)
        {
            long result = ErrorCodes.Success;
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            result = _freelancerBL.DeleteEducation(transaction, data, clientInfo);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

    }
}
