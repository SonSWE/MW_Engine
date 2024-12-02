using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.Services.SystemCodeServices
{
    public class SystemCodeService : MasterDataBaseService<MWSystemCode>, ISystemCodeService
    {
        private readonly ISystemCodeBL _systemCodeBL;

        public SystemCodeService(IMasterDataBaseBL<MWSystemCode> masterDataBaseDA, IDbManagement dbManagement, ISystemCodeBL systemCodeBL) : base(masterDataBaseDA, dbManagement)
        {
            _systemCodeBL = systemCodeBL;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;
        public override BaseValidator<MWSystemCode> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWSystemCode dataToValidate, MWSystemCode oldData)
        {
            return new SystemCodeValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
