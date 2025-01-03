using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using Object.Core;
using System.Data;
using Business.Core.BLs.BaseBLs;
using System.Collections.Generic;
using System;
using DataAccess.Core.FreelancerDAs;

namespace Business.Core.BLs.ProposalBLs
{
    public class ProposalBL : MasterDataBaseBL<MWProposal>, IProposalBL
    {
        private readonly IFreelancerDA _freelancerDA;
        public override string ProfileKeyField => Const.ProfileKeyField.Proposal;
        public override string DbTable => Const.DbTable.MWProposal;

        public ProposalBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IFreelancerDA freelancerDA) : base(dbManagement, loggingManagement)
        {
            _freelancerDA = freelancerDA;
        }
        public override MWProposal GetDetailById(IDbTransaction transaction, string id)
        {
            var data = base.GetDetailById(transaction, id);

            if (data != null)
            {
                data.Freelancer = _freelancerDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWProposal.FreelancerId), data.FreelancerId } }, transaction) ?? new();
            }
            return data;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWProposal data)
        {
            //tự sinh id
            data.ProposalId = "PR" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}