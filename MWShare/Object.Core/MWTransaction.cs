using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWTransaction, ViewName = $"VW_{Const.DbTable.MWTransaction}")]
    public sealed class MWTransaction : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string TransactionId { get; set; }
        public string WalletId { get; set; }
        public long Amount { get; set; } //số dư
        public string TransactionType { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string TransactionTypeText { get; set; }
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }

        public string Description { get; set; }
        public string CancelReason { get; set; }
        public DateTime TransactionDate { get; set; }

        //thông tin tài khoản nhận tiền
        public string WalletReceiveId { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string WalletReceiveName { get; set; }
        //số tài khoản chuyển tiền
        public string WalletTransferId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string WalletTransferName { get; set; }
    }
}
