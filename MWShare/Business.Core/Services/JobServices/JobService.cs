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
using Object;

namespace Business.Core.Services.JobServices
{
    public class JobService : MasterDataBaseService<MWJob>, IJobService
    {

        public JobService(IMasterDataBaseBL<MWJob> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Job;
        public override BaseValidator<MWJob> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWJob dataToValidate, MWJob oldData)
        {
            return new JobValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
    }
}
