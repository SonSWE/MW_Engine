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

namespace Business.Core.BLs.ProposalBLs
{
    public class ProposalBL : MasterDataBaseBL<MWProposal>, IProposalBL
    {
        private readonly IProposalDA _proposalDA;
        private readonly IProposalFileAttachDA _proposalFileAttachDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Proposal;
        public override string DbTable => Const.DbTable.MWProposal;

        public ProposalBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IProposalDA proposalDA, IProposalFileAttachDA proposalFileAttachDA) : base(dbManagement, loggingManagement)
        {
            _proposalDA = proposalDA;
            _proposalFileAttachDA = proposalFileAttachDA;
        }

        public override MWProposal GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWProposal data = base.GetDetailById(transaction, id);
            if (data != null && !string.IsNullOrEmpty(data.JobId))
            {
                data.FileAttaches = _proposalFileAttachDA.GetView(new
                {
                    data.ProposalId,
                }, transaction).ToList() ?? new();

            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWProposal data)
        {
            //tự sinh id
            data.ProposalId = "PR" + _proposalDA.GetNextSequenceValue(transaction).ToString();
        }

        public override long InsertChildData(IDbTransaction transaction, MWProposal data, MWProposal oldData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (resultValues > 0 && data?.FileAttaches?.Count > 0)
            {
                data.FileAttaches.ForEach(x =>
                {
                    x.ProposalId = data.ProposalId;
                });

                var insertedCount = _proposalFileAttachDA.Insert(data.FileAttaches, transaction);
                resultValues = insertedCount == data.FileAttaches.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }


            return resultValues;
        }

        public override long DeleteChildData(IDbTransaction transaction, string id, MWProposal deleteData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (resultValues > 0 && deleteData?.FileAttaches?.Count > 0)
            {
                deleteData.FileAttaches.ForEach(x =>
                {
                    x.ProposalId = deleteData.ProposalId;
                });

                var insertedCount = _proposalFileAttachDA.Delete(deleteData.FileAttaches, transaction);
                resultValues = insertedCount == deleteData.FileAttaches.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }
    }
}
