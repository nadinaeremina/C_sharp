using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Queuee
{
    class Program
    {
        static void Main(string[] args)
        {
            // вытащить эл-т из очереди по индексу нельзя

            //1
            Queue queue1 = new Queue();
            Queue queue2 = new Queue(3);
            Queue queue3 = new Queue(3, 3.5f); 
            // коэф-т роста по умолч. равен 2, здесь он 3.5 (диапозон от 1-10)
            // насколько будет увеличиваться размер 
            Queue queue4 = new Queue(new ArrayList { "one", 8.4 }); // принимает любые типы

            //2
            // достать эл-т по индексу из очереди нельяз // first in first out
            //Write("Метод Enqueue(): "); // положить в очередь (только в хвот)
            //Queue q = new Queue();
            //for (int i = 1; i < 4; i++)
            //{
            //    q.Enqueue(i);
            //    WriteLine();
            //    WriteLine(q.Dequeue()); // достать из очереди - посмотреть (только с головы)
            //}
            //WriteLine();

            //3
            Write("Метод Peek(): ");
            Queue q = new Queue();
            for (int i = 1; i < 3; i++)
                q.Enqueue(i);

            WriteLine();
            WriteLine("******************************");

            WriteLine(q.Peek()); // посмотреть первый эл-т, помещ-ый в кол-цию, не удаляя его

            foreach (int i in q)
                WriteLine(i);

            WriteLine(q.Contains(10)); // есть ли такой эл-т в кол-ции
        }
    }
}
