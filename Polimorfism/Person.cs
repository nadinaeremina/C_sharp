using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    // явная реализация у дочерних классов, об-ты этого класса создав-ся не будут, даже кон-ров нет
    public abstract class Person //абстрактный класс - класс, у кот. один из методов яв-ся абстрактным (нет реализации)
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
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {BD}";
        }

        //public virtual void Function_1() // обьявили виртуальный метод у базового класса
        //{
        //    Console.WriteLine("**********************Function1 Person");
        //}

        public abstract void Function_1();
        public abstract void Function_2();

        // public virtual void Function_1()=0; // чисто виртуальный метод // нет реализации
    }
}
