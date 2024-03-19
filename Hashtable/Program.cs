using System.Collections;
using static System.Console;

namespace SimpleProject
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName, -10} {LastName, -10}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1
            // быстро ищет эл-ты, быстро извлекает // динамическая коробочка, пределов размера нет 
            // ключи должны быть оригинальными, значения могут повторяться
            //Hashtable hash = new Hashtable(); 

            //hash.Add(1, "one"); // ключ и значение, типы могут быть разными
            //hash.Add(2, "two");
            //hash.Add("three", 3);

            //foreach (object o in hash.Keys) // идем по ключам
            //    Write(o.ToString() + " ");

            //WriteLine();

            //foreach (object o in hash.Values) // идем по значениям
            //    Write(o.ToString() + " ");

            //WriteLine();
            //WriteLine("****************************************");

            ////1.1
            //foreach (object o in hash.Keys) // выводим ключ и значение
            //WriteLine($" {o, -5} {hash[o], -10}");

            // 2
            //hash.Add("four", 4); // добавление эл-та хаотично (положение опред-ся по внутр. хэшкоду)
            //hash.Remove(1); // удаляет первый эл-т по ключу

            //WriteLine("****************************************");

            //foreach (object o in hash.Keys)
            //    Write($" {o,-5} {hash[o],-10}");

            //WriteLine();

            ////3
            //WriteLine(hash.Contains("three")); // метод ищет указанный ключ
            //WriteLine(hash.ContainsKey(2)); // идентичный метод (ищет ключ)
            //WriteLine(hash.ContainsValue("one")); // метод ищет указанное значение
            // ищет до первого попадания

            //4 class

            Hashtable persons = new Hashtable();
            persons.Add(1, new Person { FirstName = "PN2", LastName = "PLN2" }); // 1-ключ, 'Person'-значение
            persons.Add(10, new Person { FirstName = "PN10", LastName = "PLN10" });
            persons.Add(21, new Person { FirstName = "PN21", LastName = "PLN21" });

            foreach (object item in persons.Keys)
                WriteLine($"{item,-5} {persons[item],-10}");

            Hashtable hash = new Hashtable(17); // на 17 эл-ов
            // коэффициент заполнения от 0.1 - 1, по умолч. 1.0 // размер хэш-таблицы

        }
    }
}

