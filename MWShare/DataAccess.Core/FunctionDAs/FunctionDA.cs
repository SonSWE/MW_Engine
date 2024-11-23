using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;

namespace DataAccess.Core.FunctionDAs
{
    public sealed class FunctionDA : BaseDA<MWFunction>, IFunctionDA
    {
        public FunctionDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
