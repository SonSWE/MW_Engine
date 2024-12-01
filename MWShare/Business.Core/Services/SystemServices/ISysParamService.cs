using Object.Core;
using System.Collections.Generic;

namespace Business.Core.Services.SystemServices
{
    public interface ISysParamService
    {
        List<MWSysParam> GetAll();
    }
}
