using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWAccountClient, ViewName = $"VW_{Const.DbTable.MWAccountClient}")]
    public sealed class MWAccountClient : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ClientId { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }

    }
}
