using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    class Worker : Person
    {
        public string Post { get; set; }
        public Worker(string firstName, string lastName, DateTime b) : base(firstName, lastName, b) { }
        public Worker(string firstName, string lastName, DateTime b, string post) : base(firstName, lastName, b)
        {
            Post = post;
        }
        public override string ToString()
        {
            return base.ToString() + $" {Post}";
        }
        public override void Function_1()
        {
            Console.WriteLine("**********************Function1 Worker");
        }
        public override void Function_2()
        {
            throw new NotImplementedException();
        }
    }
}
