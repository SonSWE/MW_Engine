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
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string JobTitle { get; set; }
        public string ContractId { get; set; }
        public string FreelancerId { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }

        public string Images { get; set; }
    }
}
