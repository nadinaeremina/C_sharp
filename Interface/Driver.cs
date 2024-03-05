using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Driver : Employee
    {
        public string Car_make { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" {Car_make}";
        }
        public override void Report()
        {
            Console.WriteLine("Driver report");
        }
        public override void Rest()
        {
            Console.WriteLine("Driver rest");
        }
        public override void Work()
        {
            Console.WriteLine("Driver work");
        }
    }
}

