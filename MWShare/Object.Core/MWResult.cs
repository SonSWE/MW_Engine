using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWResult, ViewName = $"VW_{Const.DbTable.MWResult}")]
    public sealed class MWResult : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ResultId { get; set; }
        [DbField(IsKey = true)]
        public string ProposalId { get; set; }
        public string FileAttach { get; set; }
        public string Status { get; set; }
       
    }
}
