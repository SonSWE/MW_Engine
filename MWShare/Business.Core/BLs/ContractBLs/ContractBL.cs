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

namespace Business.Core.BLs.ContractBLs
{
    public class ContractBL : MasterDataBaseBL<MWContract>, IContractBL
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Contract;
        public override string DbTable => Const.DbTable.MWContract;

        public ContractBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {

        }

        public override void BeforeCreate(IDbTransaction transaction, MWContract data)
        {
            //tự sinh id
            data.ContractId = "PR" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
