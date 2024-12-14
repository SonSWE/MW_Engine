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

namespace Business.Core.Services.UserServices
{
    public class UserService : MasterDataBaseService<MWUser>, IUserService
    {
        private readonly IUserBL _userBL;

        public UserService(IMasterDataBaseBL<MWUser> masterDataBaseDA, IDbManagement dbManagement, IUserBL userBL) : base(masterDataBaseDA, dbManagement)
        {
            _userBL = userBL;
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


    }
}
