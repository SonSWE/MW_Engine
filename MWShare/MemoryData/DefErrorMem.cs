using CommonLib;
using CommonLib.Constants;
using Object.Core;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MemoryData
{
    public static class DefErrorMem
    {
        private static readonly ConcurrentDictionary<string, DefError> _defErrors = new();

        //
        public static void InitData(List<DefError> defErrors)
        {
            _defErrors.Clear();
            if (defErrors != null && defErrors.Count > 0)
            {
                foreach (var item in defErrors)
                {
                    _defErrors[item.ErrNum] = item;
                }
            }
        }

        //
        public static string GetErrorDesc(string errorCode, string language = "")
        {
            long.TryParse(errorCode, out long lngErrorCode);
            return GetErrorDesc(lngErrorCode, language);
        }
        public static string GetErrorDesc(long errorCode, string language = "")
        {
            Logger.log.Debug($"GET_ERROR_DES - {errorCode}");
            string errorCodeStr = errorCode.ToString();
            if (_defErrors != null && _defErrors.Count > 0 && _defErrors.ContainsKey(errorCodeStr))
            {
                if (language?.Equals("EN", System.StringComparison.OrdinalIgnoreCase) == true)
                {
                    return _defErrors[errorCodeStr]?.ErrDescEn ?? "-";
                }
                return _defErrors[errorCodeStr]?.ErrDesc ?? "-";
            }

            return "-";
        }
    }
}
