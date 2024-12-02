using CommonLib.Constants;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MemoryData
{
    public static class SkillMem
    {
        private static List<MWSkill> _skills = new();
        //
        public static void InitData(List<MWSkill> skills)
        {
            _skills = skills;
        }
        public static List<MWSkill> GetAll()
        {
            if (_skills?.Count > 0)
            {
                return _skills;
            }

            return null;
        }
        public static MWSkill GetById(string id)
        {
            if (_skills?.Count > 0 && !string.IsNullOrEmpty(id))
            {
                return _skills.FirstOrDefault(x => x.SkillId.Equals(id));
            }

            return null;
        }
    }
}
