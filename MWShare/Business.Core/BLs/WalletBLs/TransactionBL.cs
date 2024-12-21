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
using DataAccess.Core.WalletDAs;

namespace Business.Core.BLs.WalletBLs
{
    public class TransactionBL : MasterDataBaseBL<MWTransaction>, ITransactionBL
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Transaction;
        public override string DbTable => Const.DbTable.MWTransaction;

        public TransactionBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {
   
        }
        public override void BeforeCreate(IDbTransaction transaction, MWTransaction data)
        {
            //tự sinh id
            data.TransactionId = DateTime.Now.ToString("yyyyyMMddHHmm") + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
