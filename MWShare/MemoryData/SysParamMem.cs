using CommonLib.Constants;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MemoryData
{
    public static class SysParamMem
    {
        private static List<MWSysParam> _sysParams = new();
        private static string _busDate = string.Empty;

        //
        public static void InitData(List<MWSysParam> sysParams)
        {
            _sysParams = sysParams;
        }
        public static List<MWSysParam> GetAll()
        {
            if (_sysParams?.Count > 0)
            {
                return _sysParams;
            }

            return null;
        }
        public static MWSysParam GetById(string id)
        {
            if (_sysParams?.Count > 0 && !string.IsNullOrEmpty(id))
            {
                return _sysParams.FirstOrDefault(x => x.SysParamId.Equals(id));
            }

            return null;
        }

        public static string GetValueById(string id)
        {
            if (_sysParams?.Count > 0 && !string.IsNullOrEmpty(id))
            {
                return _sysParams.FirstOrDefault(x => x.SysParamId == id)?.PValue ?? string.Empty;
            }

            return string.Empty;
        }

        //
        public static string GetBusDateStr()
        {
            return _busDate;
        }
        public static DateTime GetBusDate()
        {
            if (DateTime.TryParseExact(_busDate, Const.DateFormat.ddMMyyyy_Slash, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime busDate))
                return busDate;

            return DateTime.Now.Date;
        }

        //
        public static int GetMaxRecordShow()
        {
            var sysparam = GetById("MAXRECORDSHOW");
            if (!string.IsNullOrEmpty(sysparam?.SysParamId))
            {
                _ = long.TryParse(sysparam.PValue, out long maxRecordShow);

                if (maxRecordShow > 0)
                    return maxRecordShow > int.MaxValue ? int.MaxValue : (int)maxRecordShow;
            }

            return 2000;
        }
    }
}
