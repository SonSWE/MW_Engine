using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using CommonLib.Extensions;
using System.Linq;
using System;
using ZeroMQ;

namespace Business.Core.Services.UserServices
{
    public class UserService : MasterDataBaseService<MWUser>, IUserService
    {
        public UserService(IMasterDataBaseBL<MWUser> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {

        }
        public override string ProfileKeyField => Const.ProfileKeyField.User;
        public override BaseValidator<MWUser> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWUser dataToValidate, MWUser oldData)
        {
            return new UserValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public override void BeforeCreate(IDbTransaction transaction, MWUser data)
        {
            data.IsEmailVerified = Const.YN.No;
            data.IsEkycVerified = Const.YN.No;
        }
        public long VerifyEKYC(string userName, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;


            if (string.IsNullOrEmpty(userName))
            {
                return ErrorCodes.Err_DataNull;
            }

            // Lay thong tin cu ra check
            var oldData = GetDetailById(transaction, userName);

            if (oldData == null || string.IsNullOrEmpty(userName))
            {
                return ErrorCodes.Err_NotFound;
            }

            var UpdateDate = oldData.Clone();
            UpdateDate.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            UpdateDate.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;
            UpdateDate.IsEkycVerified = Const.YN.Yes;
            UpdateDate.IsEmailVerified = Const.YN.Yes;
            //

            result = MasterDataBaseBL.Update(transaction, UpdateDate, clientInfo);

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
