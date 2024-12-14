using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWSaveJob, ViewName = $"VW_{Const.DbTable.MWSaveJob}")]
    public sealed class MWSaveJob
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        [DbField(IsKey = true)]
        public string FreelancerId { get; set; }

    }
}
