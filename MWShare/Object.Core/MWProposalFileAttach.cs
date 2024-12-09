using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWProposalFileAttach, ViewName = $"VW_{Const.DbTable.MWProposalFileAttach}")]
    public sealed class MWProposalFileAttach
    {
        [DbField(IsKey = true)]
        public string ProposalId { get; set; }
        [DbField(IsKey = true)]
        public string FileId { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FileName { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FileLink { get; set; }
    }
}
