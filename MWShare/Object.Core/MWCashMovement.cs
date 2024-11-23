using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWCashMovement, ViewName = $"VW_{Const.DbTable.MWCashMovement}")]
    public sealed class MWCashMovement : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string AccountId { get; set; }
        public string MovementId { get; set; }
        public string MovementType { get; set; }
        public string Quality { get; set; }
        public string JodId { get; set; }

    }
}
