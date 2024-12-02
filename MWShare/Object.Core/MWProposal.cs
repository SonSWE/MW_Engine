using CommonLib.Constants;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWProposal, ViewName = $"VW_{Const.DbTable.MWProposal}")]
    public sealed class MWProposal : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ProposalId { get; set; }
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        public string TalentId { get; set; }
        public string Status { get; set; }

        public string CoverLetter { get; set; }
        public string Description { get; set; }
        public string TargetTime { get; set; }
        public decimal Bid { get; set; } //giá đấu thầu
        public decimal FeeService { get; set; } //phí
        public decimal RealReceive { get; set; } //phí
        public string HourlyRate { get; set; }
        public string ReceiveRate { get; set; }
        public string FrequencyReceive { get; set; }
        public string PercentReceivePerTime { get; set; }
        public string FileAttach { get; set; }
    }
}
