using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWCategory, ViewName = $"VW_{Const.DbTable.MWCategory}")]
    public sealed class MWCategory : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string CategoryId { get; set; }
        public string Name { get; set; }

    }
}
