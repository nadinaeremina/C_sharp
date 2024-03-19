using System.Collections;
using static System.Console;
namespace SimpleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            SortedList sortedList = new SortedList(); // остортирован по ключу // ключи должны быть одного и того же типа данных
            WriteLine(sortedList.Capacity);
            sortedList.Add("one", "two"); // добавили 1 значение
            WriteLine(sortedList.Capacity); // 16 // поместим 17-ый эл-т - размер удвоится (32)

            WriteLine("************************");

            //2
            SortedList List = new SortedList();
            List.Add(2, 20);
            List.Add(1, 100);
            List.Add(3, 3);

            foreach (int i in List.GetKeyList()) // ключи
                WriteLine(i);

            WriteLine("************************");

            foreach (int i in List.GetValueList()) // значения
                WriteLine(i);

            ////3
            WriteLine("************************");

            for (int i = 0; i < List.Count; i++)
                WriteLine("Кey - " + List.GetKey(i) + " Value - " + List.GetByIndex(i));
            // 'GetKey' - достаем ключ, 'GetByIndex' - достаем значение 

            //4
            WriteLine("************************");

            // 'RemoveAt' - удаление по индексу // 'Remove' - по значению
            List.RemoveAt(1); // можно удалить не то значение, лучше удалять по значению ключа
            
            foreach (int i in List.GetKeyList())
                WriteLine("Кey - " + List.GetKey(i) + " Value - " + List.GetByIndex(i));

            List.Remove(2);

            WriteLine("************************");

            foreach (int i in List.GetKeyList())
                WriteLine("Кey - " + List.GetKey(i) + " Value - " + List.GetByIndex(i));

            WriteLine("************************");

            WriteLine($"{List.ContainsValue(250)}"); // ищем значение

            //5.1
            SortedList List1 = new SortedList();
            List1.Add(1, "one");
            List1.Add(2, "two");

            foreach (int i in List1.GetKeyList())
                WriteLine(i);

            WriteLine("************************");
            //5.2

            SortedList List2 = new SortedList();
            List2.Add("one", 1);
            List2.Add("two", 2);

            foreach (string i in List2.GetKeyList())
                WriteLine(i);

            // также, как и в 'Hashtable' - можно работать с классами
        }
    }
}
