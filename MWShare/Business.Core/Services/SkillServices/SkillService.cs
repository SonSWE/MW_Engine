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

namespace Business.Core.Services.SkillServices
{
    public class SkillService : MasterDataBaseService<MWSkill>, ISkillService
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Skill;

        public SkillService(IMasterDataBaseBL<MWSkill> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {
        }

        public override BaseValidator<MWSkill> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWSkill dataToValidate, MWSkill oldData)
        {
            return new SkillValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
