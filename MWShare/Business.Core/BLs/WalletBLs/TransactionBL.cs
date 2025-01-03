using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using System;
using System.Data;
using Business.Core.BLs.BaseBLs;
using Object;

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
