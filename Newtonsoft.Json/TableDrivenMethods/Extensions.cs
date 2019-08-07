using System;
using System.Collections.Generic;
using System.Text;

namespace TableDrivenMethods
{
    public static partial class Extensions
    {
        public static long ToUnixTimeMilliseconds(this DateTime @this)
        {
            return new DateTimeOffset(@this).ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，默认格式："yyyy.MM.dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="format"></param>
        public static string ToDateString(this DateTime @this, string format = "yyyy-MM-dd")
        {
            return @this.ToString(format);
        }

        public static DateTime ToDateTimeFormat(this DateTime @this, string format = "yyyy-MM-dd")
        {
            return DateTime.Parse(@this.ToString(format));
        }

        /// <summary>
        /// 获取时间的23点59分59秒
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime ToLastDayTime(this DateTime @this)
        {
            return @this.AddDays(1).ToDateTimeFormat().AddSeconds(-1);
        }

    }
}
