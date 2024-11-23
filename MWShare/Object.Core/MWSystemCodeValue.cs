using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWSystemCodeValue, ViewName = "VW_" +  Const.DbTable.MWSystemCodeValue)]
    public class MWSystemCodeValue
    {
        [DbField(IsKey = true)]
        public string SystemCodeId { get; set; }
        [DbField(IsKey = true)]
        public string Value { get; set; }
        public string Description { get; set; }
       
        public long Ord { get; set; }

    }
}
