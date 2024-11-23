using CommonLib.Constants;
using Object.Core.CustomAttributes;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWFunction, ViewName = $"VW_{Const.DbTable.MWFunction}")]
    public sealed class MWFunction
    {
        [DbField(IsKey = true)]
        public string FunctionId { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string FunctionType { get; set; }
        public string AppCode { get; set; }
        public string ModCode { get; set; }
        public string TlTxCd { get; set; }
        public int Position { get; set; }
        public int Deleted { get; set; }
        //
        public string ShowQuery { get; set; }
        public string ShowAdd { get; set; }
        public string ShowUpdate { get; set; }
        public string ShowDelete { get; set; }
        public string ShowCancel { get; set; }
        public string ShowExecute { get; set; }
        public string ShowApproveAdd { get; set; }
        public string ShowApproveUpdate { get; set; }
        public string ShowApproveDelete { get; set; }
        public string ShowApproveExecute { get; set; }
        public string ShowBackdate { get; set; }
        public string ShowNotification { get; set; }
        public string ShowImport { get; set; }
        public string ShowExport { get; set; }
        public string ShowPrint { get; set; }
        public string ShowCheckAccessHierachy { get; set; }
        //
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionTypeText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionTypeTextEn { get; set; }
        //
        public string ShowCopyRecord { get; set; }
        public string FunctionMenu { get; set; }
    }
}
