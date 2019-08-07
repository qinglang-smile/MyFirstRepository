using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateMethod
{
    /// <summary>
    /// 模板方法:参考 https://blog.csdn.net/carson_ho/article/details/54910518
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person stu = new Student();
            stu.EatProcess();

            Console.WriteLine("\n***********************\n");
            Person teacher = new Teacher();
            teacher.EatProcess();

            //Student stu = new Student
            //{
            //    Id = 1,
            //    Name = "Jack"
            //};
            //var (id, name) = stu;
            //Console.WriteLine(id + "\t" + name);

        }
    }
}
