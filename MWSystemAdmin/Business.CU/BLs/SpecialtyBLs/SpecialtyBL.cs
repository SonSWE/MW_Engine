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
using DataAccess.Core.SkillDAs;
using DataAccess.Core.SpencialDAs;

namespace Business.Core.BLs.SpecialtyBLs
{
    public class SpecialtyBL : MasterDataBaseBL<MWSpecialty>, ISpecialtyBL
    {
        private readonly ISpecialtyDA _specialtyDA;
        public override string ProfileKeyField => Const.ProfileKeyField.Specialty;
        public override string DbTable => Const.DbTable.MWSpecialty;

        public SpecialtyBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, ISpecialtyDA specialtyDA) : base(dbManagement, loggingManagement)
        {
            _specialtyDA = specialtyDA;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWSpecialty data)
        {
            //tự sinh id
            data.SpecialtyId = "SP" + _specialtyDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
