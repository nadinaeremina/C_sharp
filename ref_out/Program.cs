using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ref_out
{
    class Program
    {
        public static void f1(int n, int[] ar) // переменные не изменятся в оригинале
        {
            n++;
            WriteLine(n);
            WriteLine("***************");
            ar = new int[] { 10, 20, 30 };
            foreach (int i in ar) { Write($"{ i}"); }
        }

        // 'ref' - входные пар-ры, обязат-ая иниц-ция до передачи в ф-цию
        public static void f2(ref int n, ref int[] ar) // изменятся переменные в оригинале
        {
            n++;
            WriteLine(n);
            WriteLine("***************");
            ar = new int[] { 10, 20, 30 };
            foreach (int i in ar) { Write($"{ i}"); }
        }

        // 'out' - выходные пар-ры, необязат-ая иниц-ция до передачи в ф-цию
        public static void f3(out int n, out int[] ar) // изменятся переменные в оригинале
        {
            n = 15; // можно иниц-ть в ф-ции
            n++;
            WriteLine(n);
            WriteLine("***************");
            ar = new int[] { 10, 20, 30 };
            foreach (int i in ar) { Write($"{ i}"); }
        }

        static void Main(string[] args)
        {
            int num = 10;
            int[] ar1 = { 1, 2, 3, 4, 5 };
            f1(num, ar1);
            WriteLine("\n***************");
            WriteLine(num);
            foreach (int i in ar1) { Write($"{ i }"); }
            WriteLine("\n***************");

            WriteLine("\n***************");

            f2(ref num, ref ar1);
            WriteLine("\n***************");
            WriteLine(num);
            foreach (int i in ar1) { Write($"{ i }"); }

            WriteLine("\n***************");

            int num2;
            int[] ar2;
            f3(out num2, out ar2);
            WriteLine("\n***************");
            WriteLine(num2);
            foreach (int i in ar2) { Write($"{ i }"); }

            WriteLine("\n***************");
        }
    }
}
