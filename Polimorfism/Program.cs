using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
    class Program
    {
        static void Main(string[] args)
        {
            // Person p1 = new Person("PN1", "PLN1", DateTime.Now); // создать об-т абстрактного класса мы не можем

            Student s1 = new Student("SN1", "SLN1", new DateTime(2020, 10, 10), "G1");
            Student s2 = new Student("SN1", "SLN1", new DateTime(2020, 10, 10), "G1");

            Person[] persons = { s1, new Worker("W1", "WLN1", new DateTime(2000, 1, 1), "рабочий"),
            new Driver("D1", "DLN1", new DateTime(2010,1,15), "BMW"),
            new Manager("M1", "MLN1", new DateTime(2013,6,15), "банк"),
            new Driver_2("D2", "DLN2", new DateTime(2000,10,10), 123) };

            foreach (Person person in persons)
            {
                person.Function_1(); // полиморфизм // берется обьект 'Person' и приводится к нужному типу
                person.Function_2();
            }

            // если нам нужно вызвать функцию родителя - приводим к типу 'Person'
        }
    }
}
