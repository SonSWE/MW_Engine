using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerEducation, ViewName = $"VW_{Const.DbTable.MWFreelancerEducation}")]
    public sealed class MWFreelancerEducation 
    {
        [DbField(IsKey = true)]
        public string EducationId { get; set; }
        [DbField(IsKey = true)]
        public string FreelancerId { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; } //bằng cấp
        public string Major { get; set; } //chuyên ngành
        public string FromDate { get; set; } //năm bắt đầu học
        public string EndDate { get; set; } //năm tốt nghiệp
        public string Description { get; set; }
    }
}
