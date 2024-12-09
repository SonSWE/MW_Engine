using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.Services.FreelancerServices
{
    public class FreelancerService : MasterDataBaseService<MWFreelancer>, IFreelancerService
    {

        public FreelancerService(IMasterDataBaseBL<MWFreelancer> masterDataBaseDA, IDbManagement dbManagement) : base(masterDataBaseDA, dbManagement)
        {
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Freelancer;
        public override BaseValidator<MWFreelancer> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWFreelancer dataToValidate, MWFreelancer oldData)
        {
            return new FreelancerValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

    }
}
