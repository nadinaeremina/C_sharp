using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BD { get; set; }
        public Person()
        {
            FirstName = "";
            LastName = "";
        }
        public Person(string firstName, string lastName, DateTime bD)
        {
            FirstName = "";
            LastName = "";
            BD = bD;
            Console.WriteLine("Constr Person");
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {BD.ToShortDateString()}";
        }
        public void Function_1() 
        {
            Console.WriteLine("**********************Function1 Person");
        }
    }
}
