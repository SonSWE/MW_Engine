using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;
using Object.Core;


namespace DataAccess.Core.UserDAs
{
    public sealed class AccountClientDA : BaseDA<MWAccountClient>, IAccountClientDA
    {
        public AccountClientDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
