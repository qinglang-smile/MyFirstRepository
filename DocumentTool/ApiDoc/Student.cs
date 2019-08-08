using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDoc
{
    public class Student
    {
        [Description("id")]
        public int  Id { get; set; }
        [Description("年龄")]
        public int Age { get; set; }
        [Description("名字")]
        public string Name { get; set; }
    }
}
