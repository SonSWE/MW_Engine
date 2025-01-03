using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.UserServices
{
    public interface IUserService
    {
        long VerifyEKYC(string userName, ClientInfo clientInfo, out string resMessage);
    }
}
