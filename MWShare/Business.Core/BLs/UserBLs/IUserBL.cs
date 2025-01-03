using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.BLs.UserBLs
{
    public interface IUserBL
    {
        bool IsExistedUserName(IDbTransaction transaction, string username);
        int UpdateAvatar(MWUser data, IDbTransaction transaction);
    }
}
