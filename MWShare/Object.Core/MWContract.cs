using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System;
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
        public long ContractAmount { get; set; } //giá đấu thầu
        public long FeeService { get; set; } //phí
        public long RealReceive { get; set; } //nhận thực tế sau khi trừ phí
        public string Remark { get; set; }

        public string EndReason { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string EndReasonText { get; set; }
        public string EndReasonRemark { get; set; }
        public string FileAttach { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWContractResult> ContractResults { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ProposalId { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWFreelancer Freelancer { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWJob Job { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
