using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWWallet, ViewName = $"VW_{Const.DbTable.MWWallet}")]
    public sealed class MWWallet : MasterDataBase
    {
        public string UserName { get; set; }
        [DbField(IsKey = true)]
        public string WalletId { get; set; }
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        public long Balance { get; set; } //số dư

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public List<MWTransaction> Transactions { get; set; }

    }
}
