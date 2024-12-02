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
using DataAccess.Core.SystemCodeDAs;
using Business.Core.BLs.BaseBLs;
using DataAccess.Core.JobDAs;
using Object;
using DataAccess.Core.FileAttachDAs;

namespace Business.Core.BLs.JobBLs
{
    public class JobBL : MasterDataBaseBL<MWJob>, IJobBL
    {
        private readonly IProposalDA _proposalDA;
        private readonly IJobSkillDA _jobSkillDA;
        private readonly IJobFileAttachDA _jobFileAttachDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Job;
        public override string DbTable => Const.DbTable.MWJob;

        public JobBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IProposalDA proposalDA, IJobSkillDA jobSkillDA, IJobFileAttachDA jobFileAttachDA) : base(dbManagement, loggingManagement)
        {
            _proposalDA = proposalDA;
            _jobSkillDA = jobSkillDA;
            _jobFileAttachDA = jobFileAttachDA;

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

                data.FileAttaches = _jobFileAttachDA.GetView(new
                {
                    data.JobId,
                }, transaction).ToList() ?? new();

            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public override long InsertChildData(IDbTransaction transaction, MWJob data, MWJob oldData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (data != null && data.Proposals?.Count > 0)
            {
                data.Proposals.ForEach(x =>
                {
                    x.JobId = data.JobId;
                });

                var insertedCount = _proposalDA.Insert(data.Proposals, transaction);
                resultValues = insertedCount == data.Proposals.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if(resultValues > 0 && data?.JobSkills?.Count > 0)
            {
                data.JobSkills.ForEach(x =>
                {
                    x.JobId = data.JobId;
                });

                var insertedCount = _jobSkillDA.Insert(data.JobSkills, transaction);
                resultValues = insertedCount == data.Proposals.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && data?.FileAttaches?.Count > 0)
            {
                data.FileAttaches.ForEach(x =>
                {
                    x.JobId = data.JobId;
                });

                var insertedCount = _jobFileAttachDA.Insert(data.FileAttaches, transaction);
                resultValues = insertedCount == data.FileAttaches.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }


            return resultValues;
        }

        public override long DeleteChildData(IDbTransaction transaction, string id, MWJob deleteData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (deleteData != null && deleteData.Proposals?.Count > 0)
            {
                deleteData.Proposals.ForEach(x =>
                {
                    x.JobId = deleteData.JobId;
                });

                var insertedCount = _proposalDA.Delete(deleteData.Proposals, transaction);
                resultValues = insertedCount == deleteData.Proposals.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
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

            if (resultValues > 0 && deleteData?.FileAttaches?.Count > 0)
            {
                deleteData.FileAttaches.ForEach(x =>
                {
                    x.JobId = deleteData.JobId;
                });

                var insertedCount = _jobFileAttachDA.Delete(deleteData.FileAttaches, transaction);
                resultValues = insertedCount == deleteData.JobSkills.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }
    }
}
