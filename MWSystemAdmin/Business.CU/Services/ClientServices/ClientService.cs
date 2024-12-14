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

namespace Business.Core.Services.ClientServices
{
    public class ClientService : MasterDataBaseService<MWClient>, IClientService
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Client;

        public ClientService(IMasterDataBaseBL<MWClient> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {
        }

        public override BaseValidator<MWClient> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWClient dataToValidate, MWClient oldData)
        {
            return new ClientValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
