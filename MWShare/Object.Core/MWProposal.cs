﻿using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWProposal, ViewName = $"VW_{Const.DbTable.MWProposal}")]
    public sealed class MWProposal : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ProposalId { get; set; }
        //[DbField(IsKey = true)]
        public string JobId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string JobTitle { get; set; }
        //[DbField(IsKey = true)]
        public string FreelancerId { get; set; }
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        public string CoverLetter { get; set; } // thư xin việc
        public decimal BidAmount { get; set; } //giá đấu thầu
        public decimal FeeService { get; set; } //phí
        public decimal RealReceive { get; set; } //nhận thực tế sau khi trừ phí
        public string FileAttach { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWFreelancer Freelancer { get; set; }
    }
}
