using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_collector
{
    class Program
    {
        static void Main(string[] args)
        {
            // GC: 'Collect' - принудит.вызов сборщика усора
            // об-ты без ссылок (только если места не хватает)
            // 0,1,2 поколения (те, кот. не исп-ся в 0 он удаляет, ост. перекидывает в 1 поколение)
            // если все уровни заняты - переполнение памяти (ошибка)
            // GetTotalMemory() // сколько занято памяти
            // MaxGeneration() // какое макс.поколение у нас существует
            // GetGeneration() // на каком поколении находится наш обьект

            // 1
            
            //Garbage g1 = new Garbage();
            //Garbage g2 = new Garbage();
            //Garbage g3 = new Garbage();

            //Console.WriteLine("Номер поколения g1 : {0}", GC.GetGeneration(g1));
            //Console.WriteLine("Номер поколения g2 : {0}", GC.GetGeneration(g2));
            //Console.WriteLine("Номер поколения g3 : {0}", GC.GetGeneration(g3));
            //Console.WriteLine("Количество занятой памяти " + "До сбора мусора: {0} байт", GC.GetTotalMemory(false));

            //GC.Collect(0);

            //Console.WriteLine("Количество занятой памяти " + "после сбора мусора: {0} байт", GC.GetTotalMemory(false));
            //Console.WriteLine("Номер поколения g2 : {0}", GC.GetGeneration(g2));
            //Console.WriteLine("Номер поколения g3 : {0}", GC.GetGeneration(g3));
            //Console.WriteLine("Количнство занятой памяти " + "До сбора мусора: {0} байт", GC.GetTotalMemory(false));

            //GC.Collect(1);

            //Console.WriteLine("Номер поколения g3 : {0}", GC.GetGeneration(g3));
            //Console.WriteLine("Количнство занятой памяти " + "До сбора мусора: {0} байт", GC.GetTotalMemory(false));

            //GC.Collect(2);

            //Console.WriteLine("Количнство занятой памяти " + "после сбора мусора: {0} байт", GC.GetTotalMemory(false));
            //Console.WriteLine("Номер поколения g3 : {0}", GC.GetGeneration(g3));

            // 2

            Console.WriteLine("Демонстрация System.GC");
            Console.WriteLine("Максимальное поколение: {0}", GC.MaxGeneration);

            GarbageHelper hlp = new GarbageHelper();

            Console.WriteLine("Поколение объекта: {0}", GC.GetGeneration(hlp));
            Console.WriteLine("Занято памяти (байт): {0}", GC.GetTotalMemory(false));

            hlp.MakeGarbage();

            Console.WriteLine("Занято памяти (байт): {0}", GC.GetTotalMemory(false));

            GC.Collect(0);

            Console.WriteLine("Занято памяти (байт): {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Поколение объекта: {0}", GC.GetGeneration(hlp));

            GC.Collect();

            Console.WriteLine("Занято памяти (байт): {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Поколение объекта: {0}", GC.GetGeneration(hlp));

            Console.Read();
        }
    }
}
