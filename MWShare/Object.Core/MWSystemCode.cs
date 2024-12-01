using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System.Collections.Generic;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWSystemCode, ViewName = "VW_" + Const.DbTable.MWSystemCode)]
    public class MWSystemCode : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string SystemCodeId { get; set; }
        public string Name { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWSystemCodeValue> SystemCodeValues { get; set; }
    }
}
