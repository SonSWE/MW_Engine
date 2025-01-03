using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.WalletServices
{
    public interface IWalletService
    {
        long Deposit(MWTransaction data, ClientInfo clientInfo, out string resMessage);
        long Withdraw(MWTransaction data, ClientInfo clientInfo, out string resMessage);
        long Transfer(MWTransaction data, ClientInfo clientInfo, out string resMessage);
        long Transfer(IDbTransaction transaction, MWTransaction data, ClientInfo clientInfo, out string resMessage);
        MWWallet GetDetailByUserName(string userName);
        MWWallet GetDetailByUserName(IDbTransaction transaction, string userName);
        string GetWalletIdByFreelancer(string freelancerId);

    }
}
