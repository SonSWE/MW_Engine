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

namespace Business.Core.BLs.SysParamBLs
{
    public class SysParamBL : MasterDataBaseBL<MWSysParam>, ISysParamBL
    {

        public override string ProfileKeyField => Const.ProfileKeyField.SysParam;
        public override string DbTable => Const.DbTable.MWSysParam;

        public SysParamBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {
        }
    }
}
