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
using DataAccess.Core.Interfaces;
using DataAccess.Core.SystemDAs;
using System.Collections.Generic;
using Object;
using DataAccess.Core.JobDAs;
using DataAccess.Core.SkillDAs;

namespace Business.Core.BLs.SkillBLs
{
    public class SkillBL : MasterDataBaseBL<MWSkill>, ISkillBL
    {
        private readonly ISkillDA _skillDA;
        public override string ProfileKeyField => Const.ProfileKeyField.Skill;
        public override string DbTable => Const.DbTable.MWSkill;

        public SkillBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, ISkillDA skillDA) : base(dbManagement, loggingManagement)
        {
            _skillDA = skillDA;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWSkill data)
        {
            //tự sinh id
            data.SkillId = "SK" + _skillDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
