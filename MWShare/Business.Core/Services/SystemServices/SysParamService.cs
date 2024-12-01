using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.SysParamBLs;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Validators;
using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Business.Core.Services.SystemServices
{
    public class SysParamService : MasterDataBaseService<MWSysParam>, ISysParamService
    {
        private readonly ISysParamDA _sysParamDA;
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;

        public SysParamService(IMasterDataBaseBL<MWSysParam> masterDataBaseDA, IDbManagement dbManagement, ISysParamDA sysParamDA) : base(masterDataBaseDA, dbManagement)
        {
            _sysParamDA = sysParamDA;
        }

        public override BaseValidator<MWSysParam> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWSysParam dataToValidate, MWSysParam oldData)
        {
            return new SysParamValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public List<MWSysParam> GetAll()
        {
            return _sysParamDA.Get().ToList();
        }
    }
}
