using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWJobSaved, ViewName = $"{Const.DbTable.MWJobSaved}")]
    public sealed class MWJobSaved
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        [DbField(IsKey = true)]
        public string FreelancerId { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
