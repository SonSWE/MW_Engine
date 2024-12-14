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
        public string AllowExecute { get; set; }
        //
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string FunctionDescription { get; set; }

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
