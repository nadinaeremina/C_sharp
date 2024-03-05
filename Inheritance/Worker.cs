using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Worker: Person
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
        public new void Function_1() // создаем новый метод, кот.называется также, как и у родителя
        {
            Console.WriteLine("**********************Function1 Worker");
        }
    }
}
