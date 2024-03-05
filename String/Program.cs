using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// 'string' - класс
// 'Pascal case' - одинаковые маленькие буквы
// 'Camel case' - разные буквы (большие и маленькие)

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Мама мыла раму"; // динамический массив
            WriteLine(str1);

            WriteLine("***********************");

            // 'CompareTo'
            string[] str_ar = { "Иванов", "Петрова", "Иваныч", "Иван", "Петровна", "Ивановна" };
            WriteLine(str_ar[0].CompareTo(str_ar[2])); // сравниваем две строки 
            // -1 (если первый меньше второго) 0 (если равны) 1(если первый больше второго)

            Array.Sort(str_ar);

            WriteLine("***********************");

            foreach (string str in str_ar) { WriteLine(str); }

            WriteLine("***********************");

            // 'IndexOf'
            WriteLine(str1.IndexOf('ы')); // работает до первого вхождения

            WriteLine("***********************");

            // 'StartWith'
            foreach (string str in str_ar)
            {
                if (str.StartsWith("Иван", StringComparison.CurrentCultureIgnoreCase))
                    WriteLine(str);
            }

            WriteLine("***********************");

            // 'EndWith'
            foreach (string str in str_ar)
            {
                if (str.EndsWith("вна", StringComparison.CurrentCultureIgnoreCase))
                    WriteLine(str);
            }
        }
    }
}
