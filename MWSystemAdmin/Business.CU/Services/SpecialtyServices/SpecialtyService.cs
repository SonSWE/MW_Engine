using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.SysParamBLs;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Validators;
using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Business.Core.Services.SpecialtyServices
{
    public class SpecialtyService : MasterDataBaseService<MWSpecialty>, ISpecialtyService
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Specialty;

        public SpecialtyService(IMasterDataBaseBL<MWSpecialty> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {
        }

        public override BaseValidator<MWSpecialty> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWSpecialty dataToValidate, MWSpecialty oldData)
        {
            return new SpecialtyValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
