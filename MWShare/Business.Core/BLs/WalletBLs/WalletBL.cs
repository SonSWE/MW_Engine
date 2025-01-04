using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Business.Core.BLs.BaseBLs;
using Object;
using DataAccess.Core.WalletDAs;
using System.Collections.Generic;
using Object.Core;

namespace Business.Core.BLs.WalletBLs
{
    public class WalletBL : MasterDataBaseBL<MWWallet>, IWalletBL
    {
        private readonly ITransactionDA _transactionDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Wallet;
        public override string DbTable => Const.DbTable.MWWallet;

        public WalletBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, ITransactionDA transactionDA) : base(dbManagement, loggingManagement)
        {
            _transactionDA = transactionDA;
        }

        public override MWWallet GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            var data = base.GetDetailById(transaction, id);
            if (data != null && !string.IsNullOrEmpty(data.WalletId))
            {
                data.Transactions = _transactionDA.GetView(new
                {
                    data.WalletId,
                }, transaction).OrderByDescending(x => x.CreateBy).ToList() ?? new();

            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public MWWallet GetDetailByUserName(IDbTransaction transaction, string userName)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{userName}]");

            var data = _baseDA.GetViewFirstOrDefault(new Dictionary<string, object>
            {
                { nameof(MWWallet.UserName),userName},
                //{ nameof(MWWallet.Status),Const.Wallet_Status.Active},
            }, transaction);

            if (data != null && !string.IsNullOrEmpty(data.WalletId))
            {
                data.Transactions = _transactionDA.GetView(new
                {
                    data.WalletId,
                }, transaction).OrderByDescending(x => x.TransactionDate).ToList() ?? new();

            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWWallet data)
        {
            //tự sinh id
            data.WalletId = DateTime.Now.ToString("yyyyyMMddHHmm") + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
