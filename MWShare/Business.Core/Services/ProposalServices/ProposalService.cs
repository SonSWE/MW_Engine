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
using DataAccess.Core.FreelancerDAs;

namespace Business.Core.Services.ProposalServices
{
    public class ProposalService : MasterDataBaseService<MWProposal>, IProposalService
    {
        private readonly IProposalDA _proposalDA;
        private readonly IFreelancerDA _freelancerDA;
        public ProposalService(IMasterDataBaseBL<MWProposal> masterDataBaseDA, IDbManagement dbManagement, IProposalDA proposalDA, IFreelancerDA freelancerDA) : base(masterDataBaseDA, dbManagement)
        {
            _proposalDA = proposalDA;
            _freelancerDA = freelancerDA;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Proposal;
        public override BaseValidator<MWProposal> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWProposal dataToValidate, MWProposal oldData)
        {
            return new ProposalValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }

        public List<MWProposal> GetProposalByFreelancer(string freelancerId)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            return _proposalDA.GetView(new Dictionary<string, object> { { nameof(MWProposal.FreelancerId), freelancerId } }, transaction).OrderByDescending(x => x.CreateDate).ToList();
        }
        public List<MWProposal> GetProposalByJobId(string jobId)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var data = _proposalDA.GetView(new Dictionary<string, object> { { nameof(MWProposal.JobId), jobId } }, transaction).OrderByDescending(x => x.CreateDate).ToList();
            if (data != null && data?.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    data[i].Freelancer = _freelancerDA.GetViewFirstOrDefault(new Dictionary<string, object> { { nameof(MWProposal.FreelancerId), data[i].FreelancerId } }, transaction) ?? new();
                }
            }
            return data;
        }
    }
}
