using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;
using Object.Core;


namespace DataAccess.Core.ClientDAs
{
    public sealed class ClientDA : BaseDA<MWClient>, IClientDA
    {
        public ClientDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
