using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BD { get; set; }
   
        public override string ToString()
        {
            return $"{FirstName} {LastName} {BD.ToShortDateString()} ";
        }
    }
    abstract class Learning: Person
    {
        public string Education { get; set; }
        public int Year_st { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"{Education} {Year_st} ";
        }
    }
    class Employee: Person, IEmployees
    {
        public string Position { get; set; }
        public int Salary { get; set; }
        public List<Employee> ListEmpl { get ; set ; }
        public virtual void Report()
        {
            Console.WriteLine("++++++++++++++++");
        }
        public virtual void Rest()
        {
            Console.WriteLine("++++++++++++++++");
        }
        public virtual void Work()
        {
            Console.WriteLine("++++++++++++++++");
        }
        public override string ToString()
        {
            return base.ToString() + $"{Position} {Salary}";
        }
    }
    interface IStudu
    {
        bool IsStudy { get; } // св-во только обьявили
        void Study();
    }
    interface IEmployees
    {
        List<Employee> ListEmpl { get; set; }
        void Work();
        void Rest();
        void Report();
    }
}
