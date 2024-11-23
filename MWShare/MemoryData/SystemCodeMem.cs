using CommonLib.Constants;
using Object.Core;
using System.Collections.Generic;
using System.Linq;

namespace MemoryData
{
    public static class SystemCodeMem
    {
        private static readonly object _lock = new();
        private static List<MWSystemCode> _systemCodes = new();

        public static void InitData(List<MWSystemCode> systemCodes)
        {
            lock (_lock)
            {
                _systemCodes = systemCodes;
            }
        }

        public static List<MWSystemCode> GetAll()
        {
            return _systemCodes;
        }

        public static MWSystemCode GetBySystemCodeId(string systemCodeId)
        {
            lock (_lock)
            {
                return _systemCodes?.FirstOrDefault(x => string.Equals(x.SystemCodeId, systemCodeId));
            }
        }

        public static bool IsValidValue(string systemCodeId, string value)
        {
            lock (_lock)
            {
                return GetBySystemCodeId(systemCodeId)?.SystemCodeValues?.Any(x => string.Equals(x.Value, value)) ?? false;
            }
        }

        public static bool IsValidYN(string value)
        {
            return IsValidValue(Const.SystemCodeId.SYS_YN, value);
        }

        public static string GetValueDescription(string systemCodeId, string value)
        {
            lock (_lock)
            {
                var systemCodeValue = GetBySystemCodeId(systemCodeId)?.SystemCodeValues?.FirstOrDefault(x => string.Equals(x.Value, value));

                return systemCodeValue?.Description;
            }
        }
    }
}
