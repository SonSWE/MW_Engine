using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;

namespace Object.Core
{
    [DbTable]
    public sealed class MWUserFunction : MasterDataBase
    {
        public string AllowQuery { get; set; }
        public string AllowAdd { get; set; }
        public string AllowUpdate { get; set; }
        public string AllowDelete { get; set; }
        //public string AllowCancel { get; set; }
        public string AllowExecute { get; set; }
        public string AllowApproveAdd { get; set; }
        public string AllowApproveUpdate { get; set; }
        public string AllowApproveDelete { get; set; }
        public string AllowApproveExecute { get; set; }
        public string AllowBackdate { get; set; }
        public string AllowNotification { get; set; }
        public string AllowImport { get; set; }
        public string AllowExport { get; set; }
        public string AllowPrint { get; set; }
        public string AllowCheckAccessHierachy { get; set; }
        public string AllowCopyRecord { get; set; }
        public string IsOverride { get; set; }
        //
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionDescription { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionDescriptionEn { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionType { get; set; }
        //
        [DbField(IsKey = true)]
        public string UserName { get; set; }

        [DbField(IsKey = true)]
        public string FunctionId { get; set; }

        public List<MWUserFunction> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
