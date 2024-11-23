using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.AccountTalentDAs
{
    public sealed class CertificateDA : BaseDA<MWCertificate>, ICertificateDA
    {
        public CertificateDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
