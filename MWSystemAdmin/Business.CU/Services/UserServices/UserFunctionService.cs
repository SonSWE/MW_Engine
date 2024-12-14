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
    public class UserFunctionService : MasterDataBaseService<MWUserFunction>, IUserFunctionService
    {
        private readonly IUserFunctionBL _userFunctionBL;

        public UserFunctionService(IMasterDataBaseBL<MWUserFunction> masterDataBaseDA, IDbManagement dbManagement, IUserFunctionBL userFunctionBL) : base(masterDataBaseDA, dbManagement)
        {
            _userFunctionBL = userFunctionBL;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;
        public override BaseValidator<MWUserFunction> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWUserFunction dataToValidate, MWUserFunction oldData)
        {
            return new UserFunctionValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
