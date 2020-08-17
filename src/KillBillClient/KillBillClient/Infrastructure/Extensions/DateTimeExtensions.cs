using System;

namespace KillBillClient.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateString(this DateTime date)
        {
            return date.ToString("yyyy'-'MM'-'dd");
        }

        public static string ToDateStringISO(this DateTime date)
        {
            return date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }
    }
}