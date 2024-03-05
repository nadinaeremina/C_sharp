using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Driver_2: Driver
    {
        public int Tonality { get; set; }
        public Driver_2(string firstName, string lastName, DateTime b) : base(firstName, lastName, b) { }
        public Driver_2(string firstName, string lastName, DateTime b, int tonality) : base(firstName, lastName, b)
        {
            Tonality = tonality;
        }
        public override string ToString()
        {
            return base.ToString() + $" {Tonality}";
        }
        public new void Function_1() // создаем новый метод, кот.называется также, как и у родителя
        {
            Console.WriteLine("**********************Function2 Driver");
        }
    }
}
