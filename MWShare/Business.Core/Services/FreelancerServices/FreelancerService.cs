using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.FreelancerBLs;
using System;

namespace Business.Core.Services.FreelancerServices
{
    public class FreelancerService : MasterDataBaseService<MWFreelancer>, IFreelancerService
    {
        private readonly IFreelancerBL _freelancerBL;
        public FreelancerService(IMasterDataBaseBL<MWFreelancer> masterDataBaseDA, IDbManagement dbManagement, IFreelancerBL freelancerBL) : base(masterDataBaseDA, dbManagement)
        {
            _freelancerBL = freelancerBL;
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

        public long UpdateIsOpenForJob(MWFreelancer data, ClientInfo clientInfo, out string createResMessage)
        {
            createResMessage = string.Empty;
            if (data == null || string.IsNullOrEmpty(data.FreelancerId))
            {
                createResMessage = "Dữ liệu không hợp lệ";
                return -1;
            }

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            data.LastChangeBy = clientInfo.UserName;
            data.LastChangeDate = DateTime.Now;

            long result = _freelancerBL.UpdateIsOpenForJob(transaction, data);

            if (result > 0)
            {
                createResMessage = "Cập nhật thành công";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

    }
}
