﻿using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerSkill, ViewName = $"VW_{Const.DbTable.MWFreelancerSkill}")]
    public sealed class MWFreelancerSkill
    {
        [DbField(IsKey = true)]
        public string SkillId { get; set; }
        [DbField(IsKey = true)]
        public string FreelancerId { get; set; }
    }
}