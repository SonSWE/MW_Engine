using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFeedBack, ViewName = $"VW_{Const.DbTable.MWFeedBack}")]
    public sealed class MWFeedBack : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string FeedBackId { get; set; }
        public string JobId { get; set; }
        public string TalentId { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }


    }
}
