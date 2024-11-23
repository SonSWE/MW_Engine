using Object.Core;
using System.Collections.Generic;

namespace Business.Core.Services.SystemServices
{
    public interface ISysParamService
    {
        List<SysParam> GetAll();
        List<SysParam> GetByGrpName(string grp, string name);
    }
}
