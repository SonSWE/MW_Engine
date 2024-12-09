using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;
using Object.Core;
using System.Data;


namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerDA : BaseDA<MWFreelancer>, IFreelancerDA
    {
        public FreelancerDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        
    }
}
