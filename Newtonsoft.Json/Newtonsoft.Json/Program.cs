using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>
            {
                new Student(1, "1"),
                new Student(2, null),
                new Student(3, String.Empty)
            };
            //方法一:
            //JsonSerializerSettings jsetting = new JsonSerializerSettings();
            //jsetting.NullValueHandling = NullValueHandling.Ignore;

            //Console.WriteLine(JsonConvert.SerializeObject(stuList, Formatting.Indented, jsetting));

            //方法二:
            Console.WriteLine(JsonConvert.SerializeObject(stuList, Formatting.Indented));
            Console.WriteLine("--------------------------------------------------------");

            //方法三:排除Name属性
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new LimitPropsContractResolver(new string[] { "Name" }, false)
            };
            Console.WriteLine(JsonConvert.SerializeObject(stuList, Formatting.Indented, jsonSerializerSettings));
        }
    }
}
