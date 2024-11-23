using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLib.Modal
{
    public class ResultSelect
    {
        public string sql { get; set; } = string.Empty;
        public Dictionary<string, object>? param  { get; set; }
    }
}
