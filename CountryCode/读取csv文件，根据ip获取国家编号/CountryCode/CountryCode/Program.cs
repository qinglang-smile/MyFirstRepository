using CsvHelper;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using WebApiClient;
using CountryCode.WebApi;
using IPTools.Core;


namespace CountryCode
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //1) 读取csv文件
            List<CountryEntity> countryEntityList = ParseCsvData(@"D:\TestCode\CountryCode\CountryCode\Files\country-code-to-currency-code-mapping.csv");

            var groupbyCount = countryEntityList.GroupBy(x => x.CountryCode).Where(x => x.Count() > 1).ToList();
            //Console.WriteLine("CountryCode\t\tCode");
            //foreach (var item in groupbyCount)
            //{
            //    Console.WriteLine($"-----------------{item.Key}---------------------\n");
            //    foreach (var child in item.ToList())
            //    {
            //        Console.WriteLine($"{child.CountryCode}\t\t{child.Code}");
            //    }
            //}
            //提升查询速度
            IpToolSettings.LoadInternationalDbToMemory = true;
            //改变DefaultSearcher 所使用的默认 Searcher 请使用下面的代码，如果你同时安装了两个组件才会生效
            IpToolSettings.DefalutSearcherType = IpSearcherType.China;
            IpToolSettings.DefalutSearcherType = IpSearcherType.International;

            //2) 根据ip获取国家编号
            var ipInfo = IpTool.Search("171.210.12.163");
            Console.WriteLine(ipInfo.Country);
            Console.WriteLine(ipInfo.CountryCode);

            var ipInfo2 = IpTool.SearchWithI18N("171.210.12.163");
            Console.WriteLine(ipInfo2.Country);
            Console.WriteLine(ipInfo2.CountryCode);

            //3）根据国家编号获取对于的货币编号
            var code = countryEntityList.Where(x => x.CountryCode == ipInfo2.CountryCode).Select(y=>y.Code).FirstOrDefault();
            Console.WriteLine(code);

            GetIpAddress();

        }

       
        /// <summary>
        /// 读取csv
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<CountryEntity> ParseCsvData(string filePath)
        {
            List<CountryEntity> countryEntityList = new List<CountryEntity>();
            CsvReader csvReader = null;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    csvReader = new CsvReader(reader);
                    countryEntityList = csvReader.GetRecords<CountryEntity>().ToList();
                }
            }
            return countryEntityList;
        }

        /// <summary>
        /// 获取ip
        /// </summary>
        /// <returns></returns>
        private static string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostEntry(hostName);    
            IPAddress localaddr = localhost.AddressList[2];

            return localaddr.ToString();
        }
    }

    public class CountryEntity
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 国家编号
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// 货币
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
    }



}
