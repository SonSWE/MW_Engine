using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using Object.Core;

namespace DataAccess.Core.SystemDAs
{
    public sealed class SysParamDA : BaseDA<MWSysParam>, ISysParamDA
    {
        public SysParamDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
