using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWSkill, ViewName = $"VW_{Const.DbTable.MWSkill}")]
    public sealed class MWSkill : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }

    }
}
