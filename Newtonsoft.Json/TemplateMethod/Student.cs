using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class Student : Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override void Role()
        {
            Console.WriteLine("学生");
        }

        public override void EatBreakfast()
        {
            Console.WriteLine("吃包子");
        }

        public override void Transportation()
        {
            Console.WriteLine("坐校车");
        }

        public void Deconstruct(out int id, out string name)
        {
            id = Id;
            name = Name;
        }

        public Student()
        {

        }
        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
