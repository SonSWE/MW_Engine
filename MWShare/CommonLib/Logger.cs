using System.Reflection;
using System;

namespace CommonLib
{
    public class Logger
    {
        public static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static readonly NLog.Logger logData = NLog.LogManager.GetLogger("logData");
        public static readonly NLog.Logger logSendMW = NLog.LogManager.GetLogger("logSendMW");

        public static double GetProcessingMilliseconds(DateTime start)
        {
            return Math.Round(DateTime.Now.Subtract(start).TotalMilliseconds, 2);
        }

        public static string GetMethodFullName(MethodBase methodBase)
        {
            return $"{methodBase?.DeclaringType?.FullName}.{methodBase?.Name}";
        }
    }
}
