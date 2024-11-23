using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;


namespace DataAccess.Core.UserDAs
{
    public sealed class UserDA : BaseDA<MWUser>, IUserDA
    {
        public UserDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
