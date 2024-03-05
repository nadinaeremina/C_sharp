using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Driver: Person
    {
        public string Car_make { get; set; }
        public Driver(string firstName, string lastName, DateTime b) : base(firstName, lastName, b) { }
        public Driver(string firstName, string lastName, DateTime b, string car_make) : base(firstName, lastName, b)
        {
            Car_make = car_make;
        }
        public override string ToString()
        {
            return base.ToString() + $" {Car_make}";
        }
        public new void Function_1() // создаем новый метод, кот.называется также, как и у родителя
        {
            Console.WriteLine("**********************Function1 Driver");
        }
    }
}
