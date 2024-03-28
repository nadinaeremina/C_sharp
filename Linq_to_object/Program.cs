using System;
using System.Collections.Generic;
using System.Linq; // LINQ
using System.Text;
using System.Threading.Tasks;

namespace Linq_to_object
{
    /*
    LINQ - язык запросов, набор инструкций, кот. могут извлечь данные из нашей кол-ции (из опред. указанного ист-ка)

    .Net 3.5
    LINQ to object - обращение к обьектам
    LINQ  to DataBase - получение данных из DataSet - обращение к базам данных
    LINQ  to Sql - получение данных из MS SQL Server
    LINQ  to Entities - это framework
    LINQ  Parallel LINQ (PLINQ) - выполнение глубоких запросов
    LINQ  to XML - получение данных из файла XML

    Синтаксис:
    откуда будем просматривать - куда        // var res - это 'object' - родит.класс
    var res = from [name_var] in [source] 
              where [условие] 
              select [name_var]              // что показать из того, что отберем

    отложенное выполнение -  чтобы не загружать лишний раз память, всегда будут актуальные данные
    каждый рез-т вып-ия одного и того же линк-запроса по отношению к одной и той же коллекцци всегда будет содержать актуальные данные
    
    если есть необ-ть в немедленном запросе - нужно рез-т сразу привести к кол-ции типа ToList(), либо ToArray()

    ascending - сортировка прямая // по умолчанию // по возрастанию // писать его не об-но
    descending - сортировка обратная // писать об-но
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 18, 71, 61, 28, 15, 82, 9, 31, 12, 83, 58, 25 };

            //// 1 // без 'where'
            //IEnumerable<int> res = from i in array // 'IEnumerableE' - обобщенный интерфейс - возвращает кол-цию, даже если эл-т один
            //                       // where[условие]
            //                       select i;  // всегда последний
            //// выполнение этого кусочка кода происходит не в момент создания 'res', а при обращении к нему ниже

            //foreach (int item in res)
            //   Console.Write($"{item,4}"); // здесь происходит первое обращение к 'res' и начинает вып-ся код выше

            //Console.WriteLine();
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");

            //// 2 // c 'where'
            //IEnumerable<int> res_1 = from i in array // 'IEnumerableE' - обобщенный интерфейс
            //                         where i % 3 == 0 // критерий отбора
            //                         select i; // всегда последний

            //foreach (int item in res_1)
            //    Console.Write($"{item,4}");

            //Console.WriteLine();
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");

            //// 3 // orderby
            //IEnumerable<int> res_2 = from i in array // 'IEnumerableE' - обобщенный интерфейс
            //                         where i % 3 == 0 // критерий отбора
            //                         orderby i descending // сортировка
            //                         select i; // всегда последний

            //foreach (int item in res_2)
            //    Console.Write($"{item,4}");

            //Console.WriteLine();
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");

            // 3 // group
            // 3.1
            IEnumerable<IGrouping<int, int>> res_3 = from i in array // 'IGrouping' - интерфейс, в него положили словарь
                                                     group i by i % 10; // 'group' - группируем ключи по признаку (остатку от деления)
                                                     // взяли 1 эл-т и сфор-ли коллекция по его остатку и т.д.

            foreach (IGrouping<int, int> key in res_3) // в ключ ушли остатки от деления
            {
                Console.Write($"{key.Key} :"); 
                foreach (int item in key) // здесь значения по ключам
                    Console.Write($"{ item,4}"); // сюда попадают только те, кот. соответсвуют такому остатку от деления

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");

            // 3 // group
            // 3.2
            IEnumerable<IGrouping<int, int>> query = from i in array 
                                                     group i by i % 10 into res_4 // 'into' - вторая группировка этих же об-ов
                                                     // взяли 1 эл-т и сфор-ли коллекция по его остатку и т.д.
                                                     // 'res_4' здесь вложенная кол-ция (одна из)
                                                     where res_4.Count() >= 2 // группируем по еще одному признаку
                                                     select res_4; // загружаем рез-т в 'query'

            foreach (IGrouping<int, int> key in query)
            {
                Console.Write($"{key.Key} :");
                foreach (int item in key)
                    Console.Write($"{item,4}");

                Console.WriteLine();
            }

            Console.WriteLine();

            // test
            string[] lorem = { "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                               "Phasellus et mi dui.", 
                               "Phasellus nisi ipsum, tempus vel velit nec, efficitur suscipit nibh.",
                               "Nulla accumsan lacus purus, nec posuere neque tempor id.",
                               "Nulla scelerisque ante eu vestibulum venenatis.",
                               "Etiam posuere nulla id ligula efficitur, sed volutpat est placerat.",
                               "Fusce aliquet tellus in turpis dapibus eleifend." };

            IEnumerable<string> query_2 = from str in lorem
                                          let words = str.Split(' ', ',', '-', ';')  // массив слов
                                          // 'let'- создает новую переменную диапозона в кач-ве врем. хранилища промеж-ых данных
                                          from w in words
                                          where w.Count() > 5
                                          select w;

            foreach (string item in query_2)
                Console.WriteLine($"{item,10}");

            Console.WriteLine(query_2.Count());
        }
    }
}
