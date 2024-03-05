using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Manager: Person
    {
        public string FieldActivity { get; set; }
        public Manager(string firstName, string lastName, DateTime b) : base(firstName, lastName, b) { }
        public Manager(string firstName, string lastName, DateTime b, string factiv) : base(firstName, lastName, b)
        {
            FieldActivity = factiv;
        }
        public override string ToString()
        {
            return base.ToString() + $" {FieldActivity}";
        }
        public new void Function_1() // создаем новый метод, кот.называется также, как и у родителя
        {
            Console.WriteLine("**********************Function1 Manager");
        }
    }
}
