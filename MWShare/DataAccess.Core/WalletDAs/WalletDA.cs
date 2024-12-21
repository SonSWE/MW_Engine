using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.WalletDAs
{
    public sealed class WalletDA : BaseDA<MWWallet>, IWalletDA
    {
        public WalletDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
