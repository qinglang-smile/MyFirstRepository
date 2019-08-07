using System;
using System.Collections.Generic;
using System.Text;

namespace TableDrivenMethods
{
    /// <summary>
    /// 针对循环时间类型: 1.每天 2.每周 3.每月 4.每年
    /// </summary>
    public enum MissionFrequencyTypeEnum
    {
        /// <summary>
        /// 每天
        /// </summary>
        Day = 1,

        /// <summary>
        /// 每周
        /// </summary>
        Week = 2,

        /// <summary>
        /// 每月
        /// </summary>
        Month = 3,

        /// <summary>
        /// 每年
        /// </summary>
        Year = 4,
    }
}
