using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerSpecialProject, ViewName = $"VW_{Const.DbTable.MWFreelancerSpecialProject}")]
    public sealed class MWFreelancerSpecialProject
    {
        [DbField(IsKey = true)]
        public string ProjectId { get; set; }
        public string FreelancerId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string FileAttach { get; set; }
       
    }
}
