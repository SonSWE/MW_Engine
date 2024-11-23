using System;
using System.Reflection;

namespace CommonLib.Constants
{
    public static class ConstLog
    {
        public const string ProcessingTime = "Processing time";

        public static string GetLogProcessingTime(DateTime start)
        {
            return $"{ConstLog.ProcessingTime}: {DateTime.Now.Subtract(start).Ticks}";
        }

        public static double GetProcessingMilliseconds(DateTime start)
        {
            return Math.Round(DateTime.Now.Subtract(start).TotalMilliseconds, 2);
        }

        public static long GetProcessingTicks(DateTime start)
        {
            return DateTime.Now.Subtract(start).Ticks;
        }

        public static string GetMethodFullName(MethodBase methodBase)
        {
            return $"{methodBase?.DeclaringType?.FullName}.{methodBase?.Name}";
        }
    }
}
