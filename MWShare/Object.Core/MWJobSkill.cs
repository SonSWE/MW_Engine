using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWJobSkill, ViewName = $"VW_{Const.DbTable.MWJobSkill}")]
    public sealed class MWJobSkill
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        public string SkillId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Name { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Description { get; set; }
    }
}
