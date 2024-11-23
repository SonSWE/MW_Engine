using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWProposal, ViewName = $"VW_{Const.DbTable.MWProposal}")]
    public sealed class MWProposal : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ProposalId { get; set; }
        public string TalentId { get; set; }
        public string JodId { get; set; }
        public string CoverLetter { get; set; }
        public string Description { get; set; }
        public string HourlyRate { get; set; }
        public string ReceiveRate { get; set; }
        public string FrequencyReceive { get; set; }
        public string PercentReceivePerTime { get; set; }
        public string FileAttach { get; set; }
    }
}
