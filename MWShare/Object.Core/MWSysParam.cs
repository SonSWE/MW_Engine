using CommonLib.Constants;
using Object.Core.CustomAttributes;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWSysParam, ViewName = "VW_" + Const.DbTable.MWSysParam)]
    public class MWSysParam : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string SysParamId { get; set; }
        public string Name { get; set; }
        public string PValue { get; set; }
        public string PType { get; set; }
        public string Content { get; set; }
        public string Status { get; set; } = string.Empty;

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
    }
}
