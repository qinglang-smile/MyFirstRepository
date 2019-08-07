using System;
using System.Collections.Generic;
using System.Text;

namespace TableDrivenMethods
{
    public static class DateTimeUtil
    {

        /// <summary>
        /// 循环每天
        /// </summary>
        /// <param name="utcNow"></param>
        public static (DateTime, DateTime) GetCycleDay(DateTime utcNow)
        {
            DateTime startTime = utcNow.ToDateTimeFormat();
            DateTime endTime = utcNow.ToLastDayTime();

            return (startTime, endTime);
        }

        /// <summary>
        /// 循环每周
        /// </summary>
        /// <param name="utcNow"></param>
        public static (DateTime, DateTime) GetCycleWeek(DateTime utcNow)
        {
            DateTime startTime = utcNow.ToDateTimeFormat();
            DateTime endTime = utcNow.AddDays(7).ToLastDayTime();

            return (startTime, endTime);
        }

        /// <summary>
        /// 循环每月
        /// </summary>
        /// <param name="utcNow"></param>
        public static (DateTime, DateTime) GetCycleMonth(DateTime utcNow)
        {
            DateTime startTime = utcNow.ToDateTimeFormat();
            DateTime endTime = utcNow.AddDays(GetMonthDay(utcNow)).ToLastDayTime();

            return (startTime, endTime);
        }

        /// <summary>
        /// 获取每个月天数
        /// </summary>
        /// <param name="utcNow"></param>
        /// <returns></returns>
        public static int GetMonthDay(DateTime utcNow)
        {
            int day = System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(utcNow.Year,
                utcNow.Month);
            return day;
        }
    }
}
