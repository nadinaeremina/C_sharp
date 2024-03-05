using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    class Driver_2 : Driver
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

        // реализовывать абстрактные методы не нужно, тк наследуемся от 'Driver'
        // если они нам понадобятся - 'override' от 'Driver'
        public override void Function_1() 
        {
            Console.WriteLine("**********************Function1 Driver_2");
        }
    }
}

