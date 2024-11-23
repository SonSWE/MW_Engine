using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFileAttach, ViewName = $"VW_{Const.DbTable.MWFileAttach}")]
    public sealed class MWFileAttach : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Link { get; set; }
      

    }
}
