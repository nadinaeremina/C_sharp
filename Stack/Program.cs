using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Stackk
{
    class Program
    {
        static void Main(string[] args)
        {
            //скольео добавили эл-ов в стэк столько и есть, так и работаем
            // first in last out

            //1.1
            ////Stack stack = new Stack();

            //1.2
            ////Stack stack2 = new Stack(5);

            //1.3
            ////Stack stack3 = new Stack(new ArrayList { 3, 4, 5, 6 });

            ////3
            ////Write("Метод Push(): \n");
            ////stack.Push("one"); // добавить
            ////stack.Push("two");
            ////stack.Push("three");
            ////foreach (string str in stack) // "tree", "two", "one"
            ////    WriteLine(str);

            ////WriteLine("******************************");

            ////4
            ////Write("\n\nМетод Pop(): \n");
            ////stack.Pop(); // извлечь (из верхушки)
            ////foreach (string str in stack)
            ////    WriteLine(str);

            ////WriteLine("******************************");

            ////5
            ////string var = (string)stack.Peek(); // просмотреть, но не извлекать 
            ////WriteLine(var);
            ////WriteLine("******************************");
            ////foreach (string str in stack)
            ////    WriteLine(str);

            //6
            //Stack s = new Stack();
            //s.Push("one");
            //s.Push("5");
            //s.Push("15.6");
            //foreach (var item in s)
            //    WriteLine(item);
            //WriteLine(s.Contains("ten")); // есть ли такой обьект
            //WriteLine(s.Contains("one"));

            //7
            //Stack s = new Stack();
            //s.Push("one");
            //s.Push("two");
            //s.Push("three");
            //WriteLine(s.Count); // реальный размер
            //s.Clear(); // очистить коллекцию
            //WriteLine(s.Count);

            //8
            //Write("\nМетод CopyTo():\n ");
            //string[] str = new string[s.Count];
            //s.CopyTo(str, 0); // копируем в 'str' из 's'
            //foreach (string item in str)
            //    WriteLine(item);
        }
    }
}
