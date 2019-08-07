using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json
{
    class Student
    {

        public int Id { get; set; }

        //方法二:
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] //只对null值有效
        public string Name { get; set; } = null;

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
