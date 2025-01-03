using Business.Core.Validators;
using DataAccess.Core.Helpers;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using System.Collections.Generic;
using DataAccess.Core.JobDAs;
using System.Linq;
using CommonLib.Extensions;
using System;
using DataAccess.Core.FreelancerDAs;
using Object;
using Business.Core.Services.WalletServices;
using MemoryData;
using Business.Core.BLs.WalletBLs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Core.Services.ContractServices
{
    public class ContractService : MasterDataBaseService<MWContract>, IContractService
    {
        private readonly IContractDA _contractDA;
        private readonly IMasterDataBaseBL<MWProposal> _proposalBL;
        private readonly IMasterDataBaseBL<MWContractResult> _contractResultBL;
        private readonly IMasterDataBaseBL<MWFeedBack> _feedBackBL;
        private readonly IFreelancerDA _freelancerDA;
        private readonly IJobDA _jobDA;

        private readonly IWalletService _walletService;


        public ContractService(IMasterDataBaseBL<MWContract> masterDataBaseDA, IDbManagement dbManagement, IContractDA contractDA,
            IMasterDataBaseBL<MWProposal> proposalBL, IFreelancerDA freelancerDA, IJobDA jobDA, IMasterDataBaseBL<MWContractResult> contractResultBL,
            IMasterDataBaseBL<MWFeedBack> feedBackBL, IWalletService walletService) : base(masterDataBaseDA, dbManagement)
        {
            _contractDA = contractDA;
            _proposalBL = proposalBL;
            _freelancerDA = freelancerDA;
            _jobDA = jobDA;
            _contractResultBL = contractResultBL;
            _feedBackBL = feedBackBL;
            _walletService = walletService;
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

            if (data != null && !string.IsNullOrEmpty(data?.ContractId))
            {
                data.Job = _jobDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWContract.JobId), data.JobId } }, transaction) ?? new();
            }

            return data;
        }


        public long SendOffer(MWContract data, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            long result = ErrorCodes.Success;

            resMessage = string.Empty;
            propertyName = string.Empty;
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            //tạo contract trạng thái chờ offer
            data.Status = Const.Contract_Status.Offer;
            data.FeeService = Convert.ToInt64(data.ContractAmount * Convert.ToDouble(SysParamMem.GetValueById("FEE_SERVICE_PER_JOB")));
            data.RealReceive = data.ContractAmount - data.FeeService;

            data.CreateBy = clientInfo.UserName;
            data.CreateDate = DateTime.Now;
            result = Create(transaction, data, clientInfo, out resMessage, out propertyName);


            if (result > 0)
            {
                //cập nhật trạng thai proposal
                //sau khi tạo hợp đồng thành công thì chuyển trạng thái proposal
                result = UpdateStatusProposal(transaction, data.ProposalId, Const.Proposal_Status.Offer, clientInfo);
            }


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
        public List<MWContractResult> GetContractResultByContractId(string contractId)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var data = _contractResultBL.GetView(transaction, new Dictionary<string, object> { { nameof(MWContractResult.ContractId), contractId } }).OrderBy(x => x.CreateDate).ToList();

            return data;
        }
        public long SubmitContractResult(MWContractResult data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            long result = ErrorCodes.Err_Unknown;
            var contractData = GetDetailById(data.ContractId);
            if (contractData == null)
            {
                return ErrorCodes.Err_NotFound;
            }

            data.CreateDate = DateTime.Now;
            data.CreateBy = clientInfo.UserName;
            result = _contractResultBL.Insert(transaction, data, clientInfo);


            if (contractData.Status != Const.Contract_Status.PendingApprovalSubmit && result > 0)
            {
                contractData.Status = Const.Contract_Status.PendingApprovalSubmit;
                result = Update(transaction, contractData, clientInfo, out resMessage, out var propertyName);
            }

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
        public long DoneContract(MWFeedBack data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            long result = ErrorCodes.Err_Unknown;
            var contractData = GetDetailById(data.ContractId);
            if (contractData == null)
            {
                return ErrorCodes.Err_NotFound;
            }

            data.CreateDate = DateTime.Now;
            data.CreateBy = clientInfo.UserName;
            result = _feedBackBL.Insert(transaction, data, clientInfo);


            if (result > 0)
            {
                contractData.Status = Const.Contract_Status.Done;
                result = UpdateStatus(transaction, data.ContractId, Const.Contract_Status.Done, string.Empty, clientInfo, out resMessage, out var p);
            }

            if (result > 0)
            {
                MWTransaction transactionWithdraw = new MWTransaction();
                transactionWithdraw.Amount = contractData.RealReceive;
                transactionWithdraw.Description = "Thanh toán công việc: " + contractData.JobTitle;
                transactionWithdraw.WalletId = _walletService.GetWalletIdByFreelancer(data.FreelancerId);
                transactionWithdraw.WalletReceiveId = SysParamMem.GetValueById("WALLETID_SYSTEM");


                //chuyển tiền từ tài khoản hệ thống đến tài khoản freelancer
                result = _walletService.Transfer(transactionWithdraw, clientInfo, out resMessage);
            }

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

        public long EndContract(MWContract data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            long result = ErrorCodes.Err_Unknown;
            var contractData = GetDetailById(data.ContractId);
            if (contractData == null)
            {
                return ErrorCodes.Err_NotFound;
            }

            var newData = contractData.Clone();

            newData.LastChangeBy = clientInfo.UserName;
            newData.LastChangeDate = DateTime.Now;
            newData.Status = Const.Contract_Status.PendingApprovalEnd;
            newData.EndReason = data.EndReason;
            newData.EndReasonRemark = data.EndReasonRemark;
            newData.FileAttach = data.FileAttach;


            result = Update(transaction, newData, clientInfo, out resMessage, out var p);

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

        public long ApprovalContractComplaint(string id, string status, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            long result = ErrorCodes.Success;
            var contractData = GetDetailById(id);
            if (contractData == null)
            {
                return ErrorCodes.Err_NotFound;
            }

            var newData = contractData.Clone();


            if (status == Const.Contract_Complaint_Status.Accept)
            {
                if (newData.EndReason == Const.Contract_EndReason.Other)
                {

                    //nếu client đơn phương chấm dứt thì trả tiền cho freelancer
                    MWTransaction transactionWithdraw = new MWTransaction();
                    transactionWithdraw.Amount = contractData.RealReceive;
                    transactionWithdraw.Description = "Thanh toán công việc: " + contractData.JobTitle;
                    transactionWithdraw.WalletId = _walletService.GetWalletIdByFreelancer(contractData.FreelancerId);
                    transactionWithdraw.WalletReceiveId = SysParamMem.GetValueById("WALLETID_SYSTEM");


                    //chuyển tiền từ tài khoản hệ thống đến tài khoản freelancer
                    result = _walletService.Transfer(transactionWithdraw, clientInfo, out resMessage);

                }
                else
                {
                    //nếu freelancer làm sai hợp đồng thì trả tiền cho client
                    MWTransaction transactionWithdraw = new MWTransaction();
                    transactionWithdraw.Amount = contractData.ContractAmount;
                    transactionWithdraw.Description = "Hoàn tiền công việc: " + contractData.JobTitle;
                    transactionWithdraw.WalletId = SysParamMem.GetValueById("WALLETID_SYSTEM");
                    transactionWithdraw.WalletReceiveId = clientInfo.LoggedUser.WalletId;


                    //chuyển tiền từ tài khoản hệ thống đến tài khoản freelancer
                    result = _walletService.Transfer(transactionWithdraw, clientInfo, out resMessage);
                }

                newData.Status = Const.Contract_Status.Closed;
            }
            else
            {
                //từ chối thì cập nhật trạng thái về active
                newData.Status = Const.Contract_Status.Active;
            }

            if (result > 0)
            {
                result = Update(transaction, newData, clientInfo, out resMessage, out var p);
            }


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


        public long PaymentContract(string id, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Success;

            var contract = MasterDataBaseBL.GetDetailById(transaction, id);
            if (contract == null || string.IsNullOrEmpty(contract.ContractId))
            {
                return ErrorCodes.Err_NotFound;
            }

            //thanh toán tiền
            //kiểm tra tiền trong tài khoản
            var wallet = _walletService.GetDetailByUserName(transaction, clientInfo.UserName);
            if (wallet == null || wallet.Status == Const.Wallet_Status.Inactive)
            {
                resMessage = "Trạng thái ví không hợp lệ.";
                return -1;
            }

            if (wallet.Balance < contract.ContractAmount)
            {
                resMessage = "Số dư tài khoản không đủ.";
                return -1;
            }

            MWTransaction transactionWithdraw = new MWTransaction();
            transactionWithdraw.Amount = contract.ContractAmount;
            transactionWithdraw.Description = "Thanh toán công việc: " + contract.JobTitle;
            transactionWithdraw.WalletId = clientInfo.LoggedUser.WalletId;
            transactionWithdraw.WalletReceiveId = SysParamMem.GetValueById("WALLETID_SYSTEM");


            //chuyển tiền từ tài khoản hệ thống đến tài khoản freelancer
            result = _walletService.Transfer(transactionWithdraw, clientInfo, out resMessage);


            //acitve hợp đồng
            if (result > 0)
            {
                result = UpdateStatus(transaction, id, Const.Contract_Status.Active, string.Empty, clientInfo, out resMessage, out var propertyName);
            }

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

            if (result > 0)
            {
                if (status == Const.Contract_Status.Active)
                {
                    //freelancer xác nhận thì sẽ cập nhật lại trạng thái của job
                    var oblJob = _jobDA.GetFirstOrDefault(new Dictionary<string, object> { { nameof(MWContract.JobId), data.JobId } }, transaction);
                    if (oblJob != null)
                    {
                        oblJob.Status = Const.Job_Status.Hired;
                        _jobDA.Update(oblJob, new Dictionary<string, object> { { nameof(MWContract.JobId), data.JobId } }, transaction);
                    }
                }
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

        private long UpdateStatusProposal(IDbTransaction transaction, string id, string status, ClientInfo clientInfo)
        {
            if (id == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            // Lay thong tin cu ra check
            var oldData = _proposalBL.GetDetailById(transaction, id);
            if (oldData == null || string.IsNullOrEmpty(oldData.ProposalId))
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
