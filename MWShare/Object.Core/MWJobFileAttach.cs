using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWJobFileAttach, ViewName = $"VW_{Const.DbTable.MWJobFileAttach}")]
    public sealed class MWJobFileAttach : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        [DbField(IsKey = true)]
        public string FileId { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FileName { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FileLink { get; set; }
      

    }
}
