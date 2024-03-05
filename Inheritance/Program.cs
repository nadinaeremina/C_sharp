using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("PN1", "PLN1", DateTime.Now);
            //Console.WriteLine(p1);
            //Console.WriteLine("******************************");
            Student s1 = new Student("SN1", "SLN1", new DateTime(2020, 10, 10), "G1");
            //Console.WriteLine(s1);

            //// Student s2 = new Student(); // не возьмет данные от 'Person', просто выведет пустые данные

            //p1.Function_1();
            //s1.Function_1();

            //Student s2 = new Student("SN1", "SLN1", new DateTime(2020, 10, 10), "G1");

            Person[] persons = { p1, s1, new Worker("W1", "WLN1", new DateTime(2000, 1, 1), "рабочий"),
            new Driver("D1", "DLN1", new DateTime(2010,1,15), "BMW"),
            new Manager("M1", "MLN1", new DateTime(2013,6,15), "банк"),
            new Driver_2("D2", "DLN2", new DateTime(2000,10,10), 123) };
            // здесь лежат ссылки на один и тот же базовый класс

            foreach (Person person in persons)
            {
                // person.Function_1();

                // 1
                //try
                //{
                //    ((Student)person).Function_1();
                //}
                //catch (Exception)
                //{
                //}

                //// 2 // as - приведение типа 
                //Worker w1 = person as Worker;
                //if (w1 != null) { w1.Function_1(); }

                // 3 // is - проверка, возможно ли привести, as - само приведение
                if (person is Driver)
                    (person as Driver).Function_1();
                if (person is Driver_2)
                    (person as Driver_2).Function_1();
                // если в 'Driver_2' нет своей 'Function_1' - то он возьмет ее из родит.класса 'Driver'
            }
        }
    }
}
