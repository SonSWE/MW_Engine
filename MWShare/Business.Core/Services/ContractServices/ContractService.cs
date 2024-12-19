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
using DataAccess.Core.JobDAs;
using System.Linq;
using CommonLib.Extensions;
using System;
using Business.Core.BLs.ProposalBLs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DataAccess.Core.FreelancerDAs;

namespace Business.Core.Services.ContractServices
{
    public class ContractService : MasterDataBaseService<MWContract>, IContractService
    {
        private readonly IContractDA _contractDA;
        private readonly IMasterDataBaseBL<MWProposal> _proposalBL;
        private readonly IFreelancerDA _freelancerDA;
        private readonly IJobDA _jobDA;

        public ContractService(IMasterDataBaseBL<MWContract> masterDataBaseDA, IDbManagement dbManagement, IContractDA contractDA, 
            IMasterDataBaseBL<MWProposal> proposalBL, IFreelancerDA freelancerDA, IJobDA jobDA) : base(masterDataBaseDA, dbManagement)
        {
            _contractDA = contractDA;
            _proposalBL = proposalBL;
            _freelancerDA = freelancerDA;
            _jobDA = jobDA;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Contract;
        public override BaseValidator<MWContract> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWContract dataToValidate, MWContract oldData)
        {
            return new ContractValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public override MWContract GetDetailById(IDbTransaction transaction, string id)
        {
            var data = base.GetDetailById(transaction, id);

            if(data != null && !string.IsNullOrEmpty(data?.ContractId))
            {
                data.Job = _jobDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWContract.JobId), data.JobId } }, transaction) ?? new();
            }

            return data;
        }


        public override void BeforeCreate(IDbTransaction transaction, MWContract data)
        {
            data.Status = Const.Contract_Status.Pending;
        }

        public virtual bool OnCreated(IDbTransaction transaction, MWContract data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            resCode = 0;
            resMessage = string.Empty;
            //sau khi tạo hợp đồng thành công thì chuyển trạng thái proposal
            UpdateSatusProposal(transaction, data.ProposalId, Const.Proposal_Status.Offer, clientInfo);

            return true;
        }


        public List<MWContract> GetContractByFreelancer(string freelancerId)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            return _contractDA.GetView(new Dictionary<string, object> { { nameof(MWContract.FreelancerId), freelancerId } }, transaction).OrderByDescending(x => x.CreateDate).ToList();
        }

        public List<MWContract> GetContractByJobId(string jobId)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var data = _contractDA.GetView(new Dictionary<string, object> { { nameof(MWContract.JobId), jobId } }, transaction).OrderByDescending(x => x.CreateDate).ToList();
            if (data != null && data?.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    data[i].Freelancer = _freelancerDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWContract.FreelancerId), data[i].FreelancerId } }, transaction) ?? new();

                    //data[i].Job = _jobDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWContract.JobId), data[i].JobId } }, transaction) ?? new();
                }
            }
            return data;
        }

        public long Submit(string id, string des, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var result = UpdateStatus(transaction, id, Const.Contract_Status.PendingApprovalSubmit, des, clientInfo, out resMessage, out propertyName);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long UpdateStatus(string id, string status, string des, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var result = UpdateStatus(transaction, id, status, des, clientInfo, out resMessage, out propertyName);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        private long UpdateStatus(IDbTransaction transaction, string id, string status, string des, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            resMessage = string.Empty;
            propertyName = string.Empty;

            if (id == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            // Lay thong tin cu ra check
            var oldData = MasterDataBaseBL.GetDetailById(transaction, id);
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }

            var data = oldData.Clone();
            //
            data.TrimStringProperty();

            data.Status = status;
            data.RejectDes = des;
            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;


            //
            BeforeUpdate(transaction, oldData, data);

            // Validate Update
            if (!ValidateUpdate(transaction, oldData, data, clientInfo, out var validateResCode, out var validateResMessage))
            {
                resMessage = validateResMessage;
                return validateResCode;
            }

            //
            long result = MasterDataBaseBL.Update(transaction, data, clientInfo);

            if(result > 0)
            {
                //if(status == Const.Contract_Status.Done)
                //{
                //    //nếu hoàn thành dự án chuyển tiền về tài khoản freelancer

                //}
                //else if(status == Const.Contract_Status.Fail)
                //{
                //    //hợp đồng thất bại thì hoàn tiền về cho client
                //}
            }

            return result;
        }

        private long UpdateSatusProposal(IDbTransaction transaction, string id, string status, ClientInfo clientInfo)
        {
            if (id == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            // Lay thong tin cu ra check
            var oldData = _proposalBL.GetDetailById(transaction, id);
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }

            var data = oldData.Clone();

            data.Status = status;
            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;

            long result = _proposalBL.Update(transaction, data, clientInfo);

            return result;
        }
    }
}
