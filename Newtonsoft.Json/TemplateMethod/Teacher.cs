using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class Teacher : Person
    {
        public override void Role()
        {
            Console.WriteLine("老师");
        }
        public override void EatBreakfast()
        {
            Console.WriteLine("吃三明治");
        }

        public override void Transportation()
        {
            Console.WriteLine("自己开车");
        }
    }
}
