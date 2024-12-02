using CommonLib.Constants;
using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MemoryData
{
    public static class SpecialtyMem
    {
        private static List<MWSpecialty> _specialties = new();
        //
        public static void InitData(List<MWSpecialty> specialties)
        {
            _specialties = specialties;
        }
        public static List<MWSpecialty> GetAll()
        {
            if (_specialties?.Count > 0)
            {
                return _specialties;
            }

            return null;
        }
        public static MWSpecialty GetById(string id)
        {
            if (_specialties?.Count > 0 && !string.IsNullOrEmpty(id))
            {
                return _specialties.FirstOrDefault(x => x.SpecialtyId.Equals(id));
            }

            return null;
        }
    }
}
