using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWAccountTalent, ViewName = $"VW_{Const.DbTable.MWAccountTalent}")]
    public sealed class MWAccountTalent : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string TalentId { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }

    }
}
