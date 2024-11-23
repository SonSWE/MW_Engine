using DataAccess.Core.Interfaces;
using Object.Core;
using System.Collections.Generic;
using System.Linq;

namespace Business.Core.Services.SystemServices
{
    public class SysParamService : ISysParamService
    {
        private readonly ISysParamDA _sysParamDA;

        public SysParamService(ISysParamDA sysParamDA)
        {
            _sysParamDA = sysParamDA;
        }

        public List<SysParam> GetAll()
        {
            return _sysParamDA.Get()?.ToList();
        }

        public List<SysParam> GetByGrpName(string grp, string name)
        {
            return _sysParamDA.Get(new Dictionary<string, object>
            {
                { nameof(SysParam.Grp), grp },
                { nameof(SysParam.Name), name },
            })?.ToList();
        }
    }
}
