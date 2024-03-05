using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// System.Array - класс // Array - обьект класса // int [] name // обьявили только ссылку
// name = new int[5]; // выделили память // необязательно 
// name = new int[5] {3,4,5,6,7}; // обязательно должно соответствовать кол-во
// name = new int[] {3,4,5,6,7}; // массив будет размера 5
// int[] name = { 3, 4, 5, 6, 7 }; // можно и так без 'new'
// name = new int[5];
// массив заполнится: если (ссылочный тип) 'string','char' - null, 'int' - 0, 'double' - 0.0, 'bool' - false
// указатель на динамически выделенную память // статических массивов нет 
// double[,] array = new double[3,4]; // обьявление двумерного массива 
// double[,] array = new double[,]; // обьявление двумерного массива 
// double[,] array = new double[3,4] { {2,8,7,4} {3,5,6,0} {4,5,6,4}}; // инициализация
// double[,] array = { {2,8,7,4} {3,5,6,0} {4,5,6,4}}; // инициализация
// double[,,] array = { {{2,8,7,4} {3,5,6,0} {4,5,6,4}}, {{2,8,7,4} {3,5,6,0} {4,5,6,4}} }; // инициализация
// double[,,] array = new double [2,3,4] { {{2,8,7,4} {3,5,6,0} {4,5,6,4}}, {{2,8,7,4} {3,5,6,0} {4,5,6,4}} }; // инициализация

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); // только int
            int n = rand.Next(10); // от 0-10
            n = rand.Next(-15,10); // от -15 до 10
            double m = rand.Next(10) + rand.NextDouble(); // рандомим целую часть и вещественную
            WriteLine(m);

            WriteLine();
            WriteLine("**********************");

            ///////////////////////////////// 'Clone' 
            int[] ar = new int[10];

            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = rand.Next(-10, 50);
                Write($"{ ar[i]} ");
            }

            int[] temp = (int[])ar.Clone();

            WriteLine();
            WriteLine("*************************");

            foreach (int item in temp) { Write($"{item} "); }

            WriteLine();
            WriteLine("*************************");

            /////////////////////////////// 'Sort'
            Array.Sort(temp); // 

            foreach (int item in temp) { Write($"{item} "); }

            WriteLine();
            WriteLine("*************************");

            ////////////////////////////// 'Max' 'Min'

            WriteLine(temp.Max());
            WriteLine(temp.Min());

            WriteLine("*************************");

            ////////////////////////////// BinarySearch 
            // быстрый поиск // делит массив пополам, потом еще пополам
            int l = Convert.ToInt32(ReadLine());
            WriteLine(Array.BinarySearch(temp, l));

            WriteLine("*************************");

            /////////////////////////////// 'Reverse'
            Array.Reverse(temp, 4, 3); // начиная с 4го взяли 3 элемента

            foreach (int item in temp) { Write($"{item} "); }

            WriteLine();
            WriteLine("*************************");

            // jagged // зубчатые массивы
            int size = 6;
            int[][] jag1 = new int[size][]; // 6 ячеек

            // формируем размер массива
            for (int i = 0; i < jag1.Length; i++) jag1[i] = new int[rand.Next(2, 5)];

            // заполняем // выводим с помощью 'for'
            for (int i = 0; i < jag1.Length; i++)
            {
                for (int j = 0; j < jag1[i].Length; j++)
                {
                    jag1[i][j] = rand.Next(-30, 30);
                    Write($"{jag1[i][j],6}");
                }
                WriteLine();
            }

            // выводим с помощью 'foreach'
            WriteLine();
            WriteLine("*************************");

            for (int i = 0; i < jag1.Length; i++)
            {
                foreach (var item in jag1[i])
                {
                    Write($"{item,5}");
                }
                WriteLine();
            }
        }
    }
}
