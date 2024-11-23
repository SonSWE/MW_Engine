using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFeedBackImage, ViewName = $"VW_{Const.DbTable.MWFeedBackImage}")]
    public sealed class MWFeedBackImage : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string FeedBackId { get; set; }
        public string Image { get; set; }
      

    }
}
