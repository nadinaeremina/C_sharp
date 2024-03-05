using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Standart_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Firma firma = new Firma();
            //foreach (Person item in firma)
            //{
            //    WriteLine(item);
            //}

            //WriteLine("***********************");
            //firma.Sort();
            //foreach  (Person item in firma)
            //{
            //    WriteLine(item);
            //}

            Person p1 = new Person
            {
                FirstName = "F1",
                LastName = "L1",
                BD = new DateTime(2000, 10, 10),
                Passport = new Passport { Series = "AA", Number = 111111 }
            };

            // Person p2 = p1;
            Person p2 = (Person)p1.Clone();
            WriteLine(p1);
            WriteLine(p2);

            p2.LastName = "grgrd";
            p2.Passport.Series = "BB";
            WriteLine(p1);
            WriteLine(p2); // ссылки разные, но ссылаются на один и тот же адрес

            /*
            IEnumerable - перебор объектов в классе , где компонентом является коллекция/массив : GetEnumerator()
            IComparable - сортировать CompareTo() - по какому полю сортируем, 
            IComparer - класс для реализации метода Compare(obj1,  obj2) - по какому полю сортируем, Sort(класс)
            ICloneable - Clobe() - полное копирование MemberwiseClone(), два разных адреса. 
            */
        }
    }
}
