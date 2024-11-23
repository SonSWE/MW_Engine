using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.SystemCodeDAs
{
    public class SystemCodeValueDA : BaseDA<MWSystemCodeValue>, ISystemCodeValueDA
    {
        public SystemCodeValueDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
