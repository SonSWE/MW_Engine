using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerCertificateDA : BaseDA<MWFreelancerCertificate>, IFreelancerCertificateDA
    {
        public FreelancerCertificateDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
