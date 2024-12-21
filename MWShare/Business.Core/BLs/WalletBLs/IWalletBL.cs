using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.WalletBLs
{
    public interface IWalletBL
    {
        MWWallet GetDetailByUserName(IDbTransaction transaction, string userName);
    }
}
