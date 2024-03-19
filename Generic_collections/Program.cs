using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Generic_collections
{
    // 'generic' - <T> (обобщенный пар-р)

    // обобщенная кол-ция // необобщенная
    // List <Person> - ArrayList
    // Dictionary <Tkey, Tvalue> - Hashtable
                 // int   string []
                 // int   Person 
    // SortedList <Tkey, Tvalue> - SortedList
    // Stack <T> - Stack
    // Queue <T> - queue

    class Program
    {
        static void Main(string[] args)
        {
            // Словарь для хранения пар: string-int
            Dictionary<string, int> groups = new Dictionary<string, int>(); // 'string' - группа, 'int' - кол-во студентов

            //1 добавление значений в список
            groups["GR1"] = 12;
            groups.Add("GR2", 10);
            groups.Add("GR3", 10);
            groups.Add("GR4", 6);

            //2 добавление значений в список
            Dictionary<string, int> groups1 = new Dictionary<string, int> { ["GR1"] = 12, ["GR2"] = 10, ["GR3"] = 10, ["GR4"] = 6 };

            // изменение значения
            groups["GR1"] = 14; // если ключ уже сущ-ет, то он перезаписывает знач-ие, если нет - добавляет
            WriteLine("Содержимое словаря: ");
            foreach (KeyValuePair<string, int> p in groups)
                WriteLine($"{p.Key} {p.Value}");

            // удаление по значению ключа
            groups.Remove("GR4");

            // попытка добавления существующего ключа
            try
            {
                groups.Add("GR1", 15); // перезаписи здесь не произойдет
            }
            catch (ArgumentException e)
            {
                WriteLine(e.Message); // такой эл-т уже сущ-ет
            }

            // попытка обращения к несуществующему ключу
            try
            {
                WriteLine(groups["GR5"]);
            }
            catch (KeyNotFoundException e)
            {
                WriteLine(e.Message); // такого эл-та нет
            }

            // проверка существования ключа и получение значения
            int key;
            if (groups.TryGetValue("GR5", out key))
                WriteLine(key);
            else
                WriteLine("Ключ не существует");

        }
    }
}
