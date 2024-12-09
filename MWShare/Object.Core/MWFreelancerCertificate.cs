using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWFreelancerCertificate, ViewName = $"VW_{Const.DbTable.MWFreelancerCertificate}")]
    public sealed class MWFreelancerCertificate
    {
        [DbField(IsKey = true)]
        public string CertificateId { get; set; }
        public string FreelancerId { get; set; }
        public string Name { get; set; }
        public string FileAttachId { get; set; }
       
    }
}
