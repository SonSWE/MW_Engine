using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.WalletDAs
{
    public sealed class TransactionDA : BaseDA<MWTransaction>, ITransactionDA
    {
        public TransactionDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
