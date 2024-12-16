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
using System.Collections.Generic;
using Business.Core.BLs.JobBLs;

namespace Business.Core.Services.JobServices
{
    public class JobService : MasterDataBaseService<MWJob>, IJobService
    {
        private readonly IJobBL _jobBL;
        public JobService(IMasterDataBaseBL<MWJob> masterDataBaseDA, IDbManagement dbManagement, IJobBL jobBL) : base(masterDataBaseDA, dbManagement)
        {
            _jobBL = jobBL;
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

        public List<MWJob> GetSuggestByFreelancer(string freelancerId, ClientInfo clientInfo)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            if (string.IsNullOrEmpty(freelancerId) && !string.IsNullOrEmpty(clientInfo?.LoggedUser?.Freelancer?.FreelancerId))
            {
                freelancerId = clientInfo.LoggedUser.Freelancer.FreelancerId;
            }

            return _jobBL.GetSuggestByFreelancer(transaction, freelancerId);
        }
    }
}
