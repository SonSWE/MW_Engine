using CommonLib.Constants;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MemoryData
{
    public static class SysParamMem
    {
        private static List<SysParam> _sysParams = new();
        private static string _busDate = string.Empty;

        //
        public static void InitData(List<SysParam> sysParams, string busDate)
        {
            _sysParams = sysParams;
            _busDate = busDate;
        }
        public static List<SysParam> GetAll()
        {
            if (_sysParams?.Count > 0)
            {
                return _sysParams;
            }

            return null;
        }
        public static SysParam GetByGrpName(string grp, string name)
        {
            if (_sysParams?.Count > 0 && !string.IsNullOrEmpty(grp) && !string.IsNullOrEmpty(name))
            {
                return _sysParams.FirstOrDefault(x => x.Grp.Equals(grp) && x.Name.Equals(name));
            }

            return null;
        }
        public static string GetValueByGrpName(string grp, string name)
        {
            if (_sysParams?.Count > 0 && !string.IsNullOrEmpty(grp) && !string.IsNullOrEmpty(name))
            {
                return _sysParams.FirstOrDefault(x => x.Grp == grp && x.Name == name)?.PValue ?? string.Empty;
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
            var sysparam = GetByGrpName("SYSTEM", "MAXRECORDSHOW");
            if (!string.IsNullOrEmpty(sysparam?.Grp))
            {
                _ = long.TryParse(sysparam.PValue, out long maxRecordShow);

                if (maxRecordShow > 0)
                    return maxRecordShow > int.MaxValue ? int.MaxValue : (int)maxRecordShow;
            }

            return 2000;
        }

        //
        public static decimal GetDepositIMFee()
        {
            decimal.TryParse(SysParamMem.GetValueByGrpName(Const.SysParam_Grp.SystemFee, Const.SysParam_Name.DepositIM), out decimal feeValue);
            return feeValue;
        }

        //
        public static DateTime GetCotBank(out DateTime endTime)
        {
            endTime = DateTime.MinValue;

            var sysParamCoTValues = GetValueByGrpName(Const.SysParam_Grp.SystemCot, Const.SysParam_Name.CotBank)?.Split("|");
            if (sysParamCoTValues?.Length > 1)
            {
                DateTime.TryParseExact(sysParamCoTValues[1], Const.TimeFormat.HHmm, CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime);
            }

            if (sysParamCoTValues?.Length > 0)
            {
                DateTime.TryParseExact(sysParamCoTValues[0], Const.TimeFormat.HHmm, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTime);
                return startTime;
            }

            return DateTime.MinValue;
        }

        //
        public static DateTime GetCotVSD(out DateTime endTime)
        {
            endTime = DateTime.MinValue;

            var sysParamCoTValues = GetValueByGrpName(Const.SysParam_Grp.SystemCot, Const.SysParam_Name.CotVSD)?.Split("|");
            if (sysParamCoTValues?.Length > 1)
            {
                DateTime.TryParseExact(sysParamCoTValues[1], Const.TimeFormat.HHmm, CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime);
            }

            if (sysParamCoTValues?.Length > 0)
            {
                DateTime.TryParseExact(sysParamCoTValues[0], Const.TimeFormat.HHmm, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTime);
                return startTime;
            }

            return DateTime.MinValue;
        }

        //
        public static decimal GetWithdrawIMFee()
        {
            _ = decimal.TryParse(SysParamMem.GetValueByGrpName(Const.SysParam_Grp.SystemFee, Const.SysParam_Name.WithdrawIM), out decimal feeValue);
            return feeValue;
        }
    }
}
