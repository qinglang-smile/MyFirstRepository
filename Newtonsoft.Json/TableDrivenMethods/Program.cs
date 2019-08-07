using System;
using System.Collections.Generic;

namespace TableDrivenMethods
{
    class Program
    {
        /// <summary>
        /// MissionFrequencyTypeEnum 键TKey
        /// Func<DateTime, (DateTime, DateTime)> TValue  泛型委托,传入的参数是:DateTime 返回元组ValueTuple
        /// 
        /// </summary>
        private static readonly Dictionary<MissionFrequencyTypeEnum, Func<DateTime, (DateTime, DateTime)>> _cycleTimeDict =
            new Dictionary<MissionFrequencyTypeEnum, Func<DateTime, (DateTime startTime, DateTime endTime)>>
            {
                [MissionFrequencyTypeEnum.Day] = DateTimeUtil.GetCycleDay,
                [MissionFrequencyTypeEnum.Week] = DateTimeUtil.GetCycleWeek,
                [MissionFrequencyTypeEnum.Month] = DateTimeUtil.GetCycleMonth,
            };
        
        static void Main(string[] args)
        {
            //调用
            var (startTime, endTime) = CalculationTime(MissionFrequencyTypeEnum.Day, DateTime.Now);

            //1.未命名的元组,访问方式和之前元组相同
            var namTuple = ("one", "two");
            var b = namTuple.Item1;

            //2.带有命名的元组
            var nameValueTuple = (first: "one", second: "two");
            b = nameValueTuple.first;


        }
        /// <summary>
        /// 计算任务的:开始时间,结束时间
        /// </summary>
        /// 
        /// <param name="missionFrequencyTypeEnum">任务类型:每天,每周,每月,每年</param>
        /// <param name="utcNow">现在时间</param>
        public static (DateTime startTime, DateTime endTime) CalculationTime(MissionFrequencyTypeEnum missionFrequencyTypeEnum, DateTime utcNow)
        {
            return _cycleTimeDict[missionFrequencyTypeEnum](utcNow);//正在调用的时候执行具体某个方法
        }
    }
}
