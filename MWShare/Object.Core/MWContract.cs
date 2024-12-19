using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWContract, ViewName = $"VW_{Const.DbTable.MWContract}")]
    public sealed class MWContract : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ContractId { get; set; }
        //[DbField(IsKey = true)]
        public string JobId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string JobTitle { get; set; }
        //[DbField(IsKey = true)]
        public string FreelancerId { get; set; }
        public string RejectDes { get; set; }
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        public decimal Bid { get; set; } //giá đấu thầu
        public decimal FeeService { get; set; } //phí
        public decimal RealReceive { get; set; } //nhận thực tế sau khi trừ phí
        public string Remark { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWProposalFileAttach> FileAttaches { get; set; } //file đính kèm

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ProposalId { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWFreelancer Freelancer { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWJob Job { get; set; }
    }
}
