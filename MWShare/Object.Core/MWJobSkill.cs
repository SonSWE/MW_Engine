using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWJobSkill, ViewName = $"VW_{Const.DbTable.MWJobSkill}")]
    public sealed class MWJobSkill : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        public string SkillId { get; set; }


    }
}
