using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWContractResult, ViewName = $"VW_{Const.DbTable.MWContractResult}")]
    public sealed class MWContractResult : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ContractResultId { get; set; }
        public string ContractId { get; set; }
        public string Remark { get; set; }
        public string FileAttach { get; set; }
    }
}
