using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWCertificate, ViewName = $"VW_{Const.DbTable.MWCertificate}")]
    public sealed class MWCertificate : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string CertificateId { get; set; }
        public string TalentId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
       
    }
}
