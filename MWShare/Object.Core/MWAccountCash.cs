using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWAccountCash, ViewName = $"VW_{Const.DbTable.MWAccountCash}")]
    public sealed class MWAccountCash : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string AccountId { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }

    }
}
