using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.AccountCashDAs
{
    public sealed class AccountCashDA : BaseDA<MWAccountCash>, IAccountCashDA
    {
        public AccountCashDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
