using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWTalentSkill, ViewName = $"VW_{Const.DbTable.MWTalentSkill}")]
    public sealed class MWTalentSkill : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string SkillId { get; set; }
        [DbField(IsKey = true)]
        public string TalentId { get; set; }
    }
}
