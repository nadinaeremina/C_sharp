using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; // можно не писать 'Console'

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// если нажать 'F12' - появится развернутая информация по каждому методу
            //Console.WriteLine("Как вас зовут?");
            //string name;
            //name = ReadLine();
            //if (name == "")
            //{
            //    Console.WriteLine("привет, мир");
            //}
            //else
            //{
            //    // Console.WriteLine("привет," + name + ")");
            //    // Console.WriteLine($"при {name} вет, )"); // форматирование строки
            //    Console.WriteLine(@"при \Nadya\ вет"); // экранирование, но не примет '{}'
            //    Console.WriteLine(@"C:\Users\Chornogor\source\repos\Program.cs"); 
            //    // экранирование часто нужно при записи адреса папки
            //}

            // 1) double
            //double n1 = 1, n2 = 3;
            //double res = n1 / n2;
            //WriteLine(res);
            //WriteLine("*******************");
            //WriteLine(res * n2);

            // 2) decimal
            //decimal n1 = 1, n2 = 3;
            //decimal res = n1 / n2;
            //WriteLine(res);
            //WriteLine("*******************");
            //WriteLine(res * n2);

            // bool n1 = true/false // строго либо то, либо то

            // примеры явного приведения
            //string number_tmp = ReadLine();
            //double n2 = -12.969;
            //int n3 = (int)n2;
            //int n4 = Convert.ToInt32(n2);
            //int n5 = Int32.Parse(number_tmp);
        }
    }
}
