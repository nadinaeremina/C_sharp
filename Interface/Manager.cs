using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Manager : Employee
    {
        public string FieldActivity { get; set; }
 
        public override string ToString()
        {
            return base.ToString() + $" {FieldActivity}";
        }
        public override void Report()
        {
            Console.WriteLine("Manager report");
        }
        public override void Rest()
        {
            Console.WriteLine("Manager rest");
        }
        public override void Work()
        {
            Console.WriteLine("Worker work");
        }
    }
}