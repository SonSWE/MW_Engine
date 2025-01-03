using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerWorkingHistory, ViewName = $"VW_{Const.DbTable.MWFreelancerWorkingHistory}")]
    public sealed class MWFreelancerWorkingHistory
    {
        [DbField(IsKey = true)]
        public string WorkingHistoryId { get; set; }
        public string FreelancerId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string FromDate { get; set; } //tháng năm bắt đầu
        public string EndDate { get; set; } //tháng năm kết thúc
        public string IsCurrentlyWorkingHere { get; set; } //vẫn đang làm việc
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsCurrentlyWorkingHereText { get; set; } //vẫn đang làm việc
        public string Description { get; set; }
    }
}
