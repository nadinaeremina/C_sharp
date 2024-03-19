using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//System.Collections // пространство, в кот.хранятся необобщенные коллекции
//System.Collections.Generic // пространство, в кот. хранятся обобщенные коллекции
//System.Collections.Concurent // коллекции, кот. позволяют работать в многопоточности
//System.Collections.Specialized // пространство, в кот. содержатся классы спец. коллекций

///////////////////////////////////////////////////////////////////////////////////////////

//System.Collections

//список элементов
//System.Collections.ArrayList
//System.Collections.Queue
//System.Collections.Stack
//System.Collections.BitArray

//списки пар ключей и значений
//System.Collections.SortedList
//System.Collections.Hashtable

///////////////////////////////////////////////////////////////////////////////////////////

//System.Collections.Specialized // пространство, в кот. содержатся классы спец. коллекций

//System.Collections.Specialized.ListDictionary - микс листа и словаря (однонаправленный список) работает медленно
//System.Collections.Specialized.HybridDictionary - внутри 2 словаря ('ListDictionary' если эл-ов десятки, а если больше - 'Hashtable')
//System.Collections.Specialized.CollectionsUtil - словарь (и ключ и значения явл-ся 'string', ключи могут повторяться)
//System.Collections.Specialized.NameValueCollection - словарь (и ключ и значение яв-ся 'string') одному ключу могут соот-ть неск. значений (ключи могут совпадать)
//System.Collections.Specialized.StringCollection - не словарь, просто коллекция, значения могут повторяться
//System.Collections.Specialized.StringDictionary - словарь (и ключ и значения явл-ся 'string', 'null' не может быть)

namespace Array_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1
            //ArrayList arrayList1 = new ArrayList();
            //WriteLine($"Вместимость по умолчанию:{ arrayList1.Capacity}");

            ////2
            //ArrayList arrayList2 = new ArrayList(5);
            //WriteLine($"Вместимость :{ arrayList2.Capacity}");

            ////3
            //ArrayList arrayList3 = new ArrayList();
            //arrayList3.Add("word"); // добавили хотя бы один эл-т - размер сразу равен 4
            //WriteLine($"Вместимость после добавления одного элемента: { arrayList3.Capacity}");

            ////4
            //arrayList3.Add("letter");
            //WriteLine($"Вместимость после добавления одного элемента: { arrayList3.Capacity}");

            ////5
            //ArrayList arrayList4 = new ArrayList();
            //WriteLine($"Вместимость :{ arrayList4.Capacity}");
            //arrayList4.Capacity = 17;
            //WriteLine($"Вместимость :{ arrayList4.Capacity}");

            ////6
            //ArrayList arrayList5 = new ArrayList(2);
            //WriteLine($"Вместимость :{ arrayList5.Capacity}");
            //arrayList5.AddRange(new int[] { 1, 2, 3});
            //WriteLine($"Вместимость :{ arrayList5.Capacity}");

            //7
            //ArrayList arrayList1 = new ArrayList(7);
            //WriteLine($"Вместимость :{ arrayList1.Capacity}");
            //arrayList1.AddRange(new int[] { 1, 2, 3 });
            //WriteLine($"Вместимость :{ arrayList1.Capacity}");
            //arrayList1.TrimToSize(); // сузить до реальной вместимости
            //WriteLine($"Вместимость уменьшена до реального  количества элементов: {arrayList1.Capacity}");
            
            //8
            //ArrayList arrayList1 = new ArrayList(new int[] { 1, 2, 3 });
            //WriteLine($"Элемент с индексом 2: { arrayList1[2]} ");

            ////9
            //ArrayList arrayList2 = new ArrayList(new string[] { "one", null, "two", "three", null }); // 'null' - элемент есть, но не проиниц-ан
            //WriteLine($"Фактическое количество элементов: { arrayList2.Count}  ");
            
            //10
            //ArrayList arrayList3 = new ArrayList();
            // могут храниться разнотипные обьекты
            //arrayList3.Add("one");
            //arrayList3.Add(10);
            //arrayList3.Add(true);
            //WriteLine("Все элементы коллекции:");
            
            ////*10.1
            //foreach (object item in arrayList3)
            //    WriteLine($"\t{item}");
            
            ////*10.2
            //foreach (object o in arrayList3)
            //    WriteLine(o.ToString());
            //int i = (int)arrayList3[1];
            //WriteLine($"\t{i}");

            //11
            ArrayList days = new ArrayList(new string[] { "Sunday", "Monday", "Tuesday", "Wednesday ", "Thursday ", "Friday", "Saturday " });
            ArrayList only = new ArrayList(days.GetRange(0, 3)); // 'GetRange' - в качестве кон-ра // из базового класса вытащить часть массива
            foreach (string s in only)
                WriteLine(s);

            //12
            ArrayList numbers = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            numbers.Insert(2, 22);
            foreach (int index in numbers)
                WriteLine(index);

            WriteLine("********************************");

            //13
            ArrayList numbers1 = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            numbers1.RemoveAt(2); // позиция
            numbers1.Remove(5); // значение
            foreach (int index in numbers1)
                WriteLine(index);

            WriteLine("********************************");

            //14
            ArrayList numbers2 = new ArrayList(new int[] { 1, 3, 2, 5, 4 });
            numbers2.Sort();
            foreach (int index in numbers2)
                WriteLine(index);

            //IndeOf(obj) - возвращает знач-ие первого эл-та
            //LastIndexOf(object) - возвращает знач-ие пеоследнего эл-та
        }
    }
}
