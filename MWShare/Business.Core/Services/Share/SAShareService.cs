using MemoryData;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Services.Share
{
    public class SAShareService : ISAShareService
    {
        public List<MWSystemCode> GetSystemCodes()
        {
            return SystemCodeMem.GetAll();
        }
    }
}
