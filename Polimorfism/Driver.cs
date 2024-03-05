using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    class Driver : Person
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
        public override void Function_1()
        {
            Console.WriteLine("**********************Function1 Driver");
        }
        public override void Function_2()
        {
            throw new NotImplementedException();
        }
        // 'saled' - запечатываем этот метод, не даем дальше переопределяться
        // только если создавать свой метод 'new', но не 'override'
        //public sealed override void Function_1()
        //{
        //    Console.WriteLine("**********************Function1 Driver");
        //}
    }
}
