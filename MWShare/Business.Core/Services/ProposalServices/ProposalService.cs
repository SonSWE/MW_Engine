﻿using Business.Core.Validators;
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

namespace Business.Core.Services.ProposalServices
{
    public class ProposalService : MasterDataBaseService<MWProposal>, IProposalService
    {
        public ProposalService(IMasterDataBaseBL<MWProposal> masterDataBaseDA, IDbManagement dbManagement, IJobBL jobBL) : base(masterDataBaseDA, dbManagement)
        {

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
    }
}
