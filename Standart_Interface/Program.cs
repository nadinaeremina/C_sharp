using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Standart_Interface
{
    interface IA
    {
        string A1(int n);
        void F1();
    }
    interface IB
    {
        int B1(int n);
        void B2();
        void F1();
    }
    interface IC: IA, IB     // наследование интерфейсов
    {
        void C1(int n);
        void F1();
    }
    class MyClass : IA, IB, IC
    {
        public string A1(int n)
        {
            throw new NotImplementedException();
        }
        public int B1(int n)
        {
            throw new NotImplementedException();
        }
        public void B2()
        {
            throw new NotImplementedException();
        }
        public void C1(int n)
        {
            throw new NotImplementedException();
        }
        public void F1() // здесь реализованы все три 'F1'
        {
            throw new NotImplementedException();
        }
        void IA.F1() // здесь реализуем только 'F1' от 'IA'
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyClass obj = new MyClass();
            //obj.A1(5);
            //IA obj_2 = new MyClass(); // обьект, кот.реализует интерфейс можно привести не к типу класса, а к типу интерфейс
            //obj_2.F1(); // тогда здесь увидим только методы интерфейса 'IA'
            //((IB)obj).F1();

            //Firma firma = new Firma();

            //foreach (Firma item in firma)
            //{
            //    WriteLine(item);
            //}

            //foreach (Person item in firma)
            //{
            //    WriteLine(item);
            //}

            //WriteLine("***********************");
            //firma.Sort();

            //foreach (Person item in firma)
            //{
            //    WriteLine(item);
            //}

            WriteLine("**********************************************");

            //firma.Sort(new Data_person());

            //foreach (Person item in firma)
            //{
            //    WriteLine(item);
            //}

            //firma.Sort(new Passport_Person());

            //foreach (Person item in firma)
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

            // Person p2 = p1; // один и тот же человек, у кот.просто один и тот же адрес, а ссылки разные
            Person p2 = (Person)p1.Clone(); // если нужен один оригинал, а второй такой же, чтобы с ним можно было что-нибудь делать
            WriteLine(p1);
            WriteLine(p2);

            p2.LastName = "grgrd";
            p2.Passport.Series = "BB";
            WriteLine(p1);
            WriteLine(p2); // ссылки разные, но ссылаются на один и тот же адрес

            /*
            IEnumerable - перебор объектов в классе, где компонентом является коллекция/массив: GetEnumerator()
            IComparable - сортировать CompareTo() - по какому полю сортируем
            IComparer - класс для реализации метода Compare(obj1, obj2) - по какому полю сортируем, Sort(класс)
            ICloneable - Clone() - полное копирование MemberwiseClone(), два разных адреса
            */
        }
    }
}
