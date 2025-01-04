using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerSpecialty, ViewName = $"VW_{Const.DbTable.MWFreelancerSpecialty}")]
    public sealed class MWFreelancerSpecialty
    {
        [DbField(IsKey = true)]
        public string SpecialtyId { get; set; }
        public string FreelancerId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Name { get; set; }
    }
}
