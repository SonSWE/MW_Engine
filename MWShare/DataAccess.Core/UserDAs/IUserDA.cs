using DataAccess.Core.Abtractions;
using Object.Core;
using System.Data;

namespace DataAccess.Core.UserDAs
{
    public interface IUserDA : IBaseDA<MWUser>
    {
        int UpdateAvatar(MWUser data, IDbTransaction transaction);
    }
}
