using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;

using Azure.Core;
using CommonLib;
using DataAccess.Helpers;



namespace Business.Cus.Services.FreelancerServices
{
    public class FreelancerService : IFreelancerService
    {
       private readonly IFreelancerBL _freelancerBL;
        public FreelancerService(IMasterDataBaseBL<MWFreelancer> masterDataBaseBL, IDbManagement dbManagement, ILoggingManagement loggingManagement)
        {
            LoggingManagement = loggingManagement;
            MasterDataBaseBL = masterDataBaseBL;
        }
        public string ProfileKeyField => Const.ProfileKeyField.Freelancer;
        public virtual ILoggingManagement LoggingManagement { get; private set; }
        public string RequestId => LoggingManagement.RequestId;

        


    }
}
