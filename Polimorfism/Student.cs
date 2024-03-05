using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    public class Student : Person
    {
        public string Group { get; set; }
        public Student() { }
        public Student(string firstName, string lastName, DateTime b) : base(firstName, lastName, b) { }
        public Student(string firstName, string lastName, DateTime b, string group) : base(firstName, lastName, b)
        {
            Group = group;
        }
        public override string ToString()
        {
            return base.ToString() + $" {Group}";
        }

        // public new void Function_1() // создаем новый метод, отличный от родителя (если подчеркивает)
        // с пом.слова 'new' скрываем любой член базового класса
        public override void Function_1()
        {
            // base.Function_1(); // взяли метод от родителя
            Console.WriteLine("**********************Function1 Student");
        }
        public override void Function_2() // скрываем метод родителя
        {
            throw new NotImplementedException();
        }

    }
}