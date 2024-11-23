using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWMessage, ViewName = $"VW_{Const.DbTable.MWMessage}")]
    public sealed class MWMessage : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string MessageId { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string ReviserId { get; set; }
        public string SendDate { get; set; }
        public string Status { get; set; }
       
    }
}
