using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Worker : Employee
    {
        public string Post { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" {Post}";
        }
        public override void Report()
        {
            Console.WriteLine("Worker report");
        }
        public override void Rest()
        {
            Console.WriteLine("Worker rest");
        }
        public override void Work()
        {
            Console.WriteLine("Worker work");
        }
    }
}