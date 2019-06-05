using CsvHelper;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using IPTools.Core;


namespace CountryCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string chinaCode = GetCurrencyCode("171.210.12.163");//中国
            Console.WriteLine(chinaCode);
            Console.WriteLine("-----------------------------------");

            string americaCode = GetCurrencyCode("207.226.141.205");//美国
            Console.WriteLine(americaCode);
            Console.WriteLine("-----------------------------------");

            string taiwanCode = GetCurrencyCode("59.125.205.87");//台湾
            Console.WriteLine(taiwanCode);
            Console.WriteLine("-----------------------------------");

            string hongKongCode = GetCurrencyCode("61.244.148.166");//香港
            Console.WriteLine(hongKongCode);
        }

        public static string GetCurrencyCode(string ipAddress)
        {
            string code = "";
            //1) 读取csv文件
            List<CountryModel> countryEntityList = ParseCsvData(@"D:\TestCode\CountryCode\CountryCode\Files\country-code-to-currency-code-mapping.csv");

            //提升查询速度
            IpToolSettings.LoadInternationalDbToMemory = true;
            //2) 改变DefaultSearcher 所使用的默认 Searcher 请使用下面的代码，如果你同时安装了两个组件才会生效
            IpToolSettings.DefalutSearcherType = IpSearcherType.China;
            IpToolSettings.DefalutSearcherType = IpSearcherType.International;

            var ipInfo2 = IpTool.SearchWithI18N(ipAddress);
            Console.WriteLine(ipInfo2.Country);
            //Console.WriteLine(ipInfo2.CountryCode);

            //3）根据国家编号获取对于的货币编号
            code = countryEntityList.Where(x => x.CountryCode == ipInfo2.CountryCode).Select(y => y.Code).FirstOrDefault();
            return code;
        }

        /// <summary>
        /// 读取csv
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<CountryModel> ParseCsvData(string filePath)
        {
            List<CountryModel> countryEntityList = new List<CountryModel>();
            CsvReader csvReader = null;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    csvReader = new CsvReader(reader);
                    countryEntityList = csvReader.GetRecords<CountryModel>().ToList();
                }
            }
            return countryEntityList;
        }
    }





}
