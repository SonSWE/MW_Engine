using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWSpecialty, ViewName = $"VW_{Const.DbTable.MWSpecialty}")]
    public sealed class MWSpecialty : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string SpecialtyId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }

    }
}
