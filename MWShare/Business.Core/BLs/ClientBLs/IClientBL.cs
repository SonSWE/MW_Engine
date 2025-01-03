using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.ClientBLs
{
    public interface IClientBL
    {
        bool IsExistedEmail(IDbTransaction transaction, string email, string clientId);
    }
}
