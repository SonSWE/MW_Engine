using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Business.Core.BLs.BaseBLs;
using DataAccess.Core.JobDAs;
using System.Collections.Generic;

namespace Business.Core.BLs.JobBLs
{
    public class JobBL : MasterDataBaseBL<MWJob>, IJobBL
    {
        private readonly IJobDA _jobDA;
        private readonly IProposalDA _proposalDA;
        private readonly IJobSkillDA _jobSkillDA;
        private readonly IMasterDataBaseBL<MWProposal> _proposalBL;


        public override string ProfileKeyField => Const.ProfileKeyField.Job;
        public override string DbTable => Const.DbTable.MWJob;

        public JobBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IProposalDA proposalDA, IJobSkillDA jobSkillDA, IJobDA jobDA, IMasterDataBaseBL<MWProposal> proposalBL) : base(dbManagement, loggingManagement)
        {
            _proposalDA = proposalDA;
            _jobSkillDA = jobSkillDA;
            _jobDA = jobDA;
            _proposalBL = proposalBL;

        }

        public override MWJob GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWJob data = base.GetDetailById(transaction, id);
            if (data != null && !string.IsNullOrEmpty(data.JobId))
            {
                data.Proposals = _proposalDA.GetView(new
                {
                    data.JobId,
                }, transaction).ToList() ?? new();

                data.JobSkills = _jobSkillDA.GetView(new
                {
                    data.JobId,
                }, transaction).ToList() ?? new();
            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWJob data)
        {
            if (string.IsNullOrEmpty(data.Status))
            {
                data.Status = Const.Job_Status.Open;
            }
            //tự sinh id
            data.JobId = "J" + _jobDA.GetNextSequenceValue(transaction).ToString();
        }

        public override long InsertData(IDbTransaction transaction, MWJob data, ClientInfo clientInfo)
        {
            if (string.IsNullOrEmpty(data.ClientId)) {
                data.ClientId = clientInfo.LoggedUser.Client?.ClientId;
            }

            return base.InsertData(transaction, data, clientInfo);
        }

        public override long InsertChildData(IDbTransaction transaction, MWJob data, MWJob oldData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (data != null && data.Proposals?.Count > 0)
            {
                long[] resProposal = new long[] { };
                data.Proposals.ForEach(x =>
                {
                    resProposal.Add(_proposalBL.Insert(transaction, x, clientInfo));
                });

                resultValues = resProposal.Any(x => x < 0) ? ErrorCodes.Err_InvalidData : ErrorCodes.Success;
            }

            if (resultValues > 0 && data?.JobSkills?.Count > 0)
            {
                data.JobSkills.ForEach(x =>
                {
                    x.JobId = data.JobId;
                });

                var insertedCount = _jobSkillDA.Insert(data.JobSkills, transaction);
                resultValues = insertedCount == data.JobSkills.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }

        public override long DeleteChildData(IDbTransaction transaction, string id, MWJob deleteData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (deleteData != null && deleteData.Proposals?.Count > 0)
            {
                long[] resProposal = new long[] { };
                deleteData.Proposals.ForEach(x =>
                {
                    resProposal.Add(_proposalBL.Delete(transaction, x, clientInfo));
                });

                //resultValues = resProposal.Any(x => x < 0) ? ErrorCodes.Err_InvalidData : ErrorCodes.Success;
                //deleteData.Proposals.ForEach(x =>
                //{
                //    x.JobId = deleteData.JobId;
                //});

                //var insertedCount = _proposalDA.Delete(deleteData.Proposals, transaction);
                //resultValues = insertedCount == deleteData.Proposals.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && deleteData?.JobSkills?.Count > 0)
            {
                deleteData.JobSkills.ForEach(x =>
                {
                    x.JobId = deleteData.JobId;
                });

                var insertedCount = _jobSkillDA.Delete(deleteData.JobSkills, transaction);
                resultValues = insertedCount == deleteData.JobSkills.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }

        public List<MWJob> GetSuggestByFreelancer(IDbTransaction transaction, string freelancerId)
        {
            var data = _jobDA.GetSuggestByFreelancer(transaction, freelancerId);

            return data;
        }

        public List<MWJob> GetByClientId(IDbTransaction transaction, string clientId)
        {
            var data = _jobDA.GetView(new Dictionary<string, object> { { nameof(MWClient.ClientId), clientId } }, transaction).OrderBy(x=>x.CreateBy).ToList();

            return data;
        }
    }
}
