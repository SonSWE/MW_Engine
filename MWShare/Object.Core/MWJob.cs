﻿using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWJob, ViewName = $"VW_{Const.DbTable.MWJob}")]
    public sealed class MWJob : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        public string ClientId { get; set; }
        public string TermType { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string TermTypeText { get; set; }
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SpecialtyId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string SpecialtyIdText { get; set; }
        public string Scope { get; set; }
        public string LevelFreelancerId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string LevelFreelancerIdText { get; set; }
        public string BudgetType { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string BudgetTypeText { get; set; }
        public string Position { get; set; }
        public decimal HourlyRateFrom { get; set; }
        public decimal HourlyRateTo { get; set; }
        public string FileAttach { get; set; }
        public long CostEstimate { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public long CountOfProposal { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public long CountOfContract { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Saved { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Applied { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWProposal> Proposals { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWJobSkill> JobSkills { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string JobSkillsText { get; set; }

        
    }
}
