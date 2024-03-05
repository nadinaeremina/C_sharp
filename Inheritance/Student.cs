using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Student : Person
    {
        public string Group { get; set; }
        public Student () {}
        public Student(string firstName, string lastName, DateTime b): base(firstName,lastName,b) { }
        public Student(string firstName, string lastName, DateTime b, string group): base(firstName,lastName,b) 
        {
            Group = group;
            Console.WriteLine("Constr Student");
        }
        public override string ToString()
        {
            return base.ToString() + $" {Group}";
        }
        public new void Function_1() // создаем новый метод, кот.называется также, как и у родителя
        {
            base.Function_1();
            Console.WriteLine("**********************Function1 Student");
        }
    }
}
