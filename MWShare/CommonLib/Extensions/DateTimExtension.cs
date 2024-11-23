using System;

namespace CommonLib.Extensions
{
    public static class DateTimExtension
    {
        public static bool IsWeekend(this DateTime date) => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        public static bool IsSaturday(this DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;
        public static bool IsSunday(this DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;
        public static bool IsMinValue(this DateTime date) => date.Date == DateTime.MinValue.Date;
        public static bool LessThan(this DateTime date, DateTime compareDate) => date.Date < compareDate.Date;
        public static bool LessThanOrEqual(this DateTime date, DateTime compareDate) => date.Date <= compareDate.Date;
        public static bool Equal(this DateTime date, DateTime compareDate) => date.Date == compareDate.Date;
        public static bool GreateThan(this DateTime date, DateTime compareDate) => date.Date > compareDate.Date;
        public static bool GreateThanOrEqual(this DateTime date, DateTime compareDate) => date.Date >= compareDate.Date;
    }
}
