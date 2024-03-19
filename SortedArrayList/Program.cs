using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SortedArrayList
{
    public class SortedArrayList : ArrayList
    {
        public void AddSorted(object item)
        {
            int position = this.BinarySearch(item); // 'BinarySearch' - сортировка // ищет эл-т и возв-ет его индекс

            if (position < 0)
                position = ~position;

            this.Insert(position, item);
        }
        public void ModifySorted(object item, int index)
        {
            this.RemoveAt(index);

            this.AddSorted(item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedArrayList sortedAL = new SortedArrayList();

            WriteLine("----- Начальные значения -------\n");
            sortedAL.AddSorted(200);
            sortedAL.AddSorted(-7);
            sortedAL.AddSorted(0);
            sortedAL.AddSorted(-20);
            sortedAL.AddSorted(56);
            sortedAL.AddSorted(200);

            foreach (int i in sortedAL)
                Write(i + " ");

            WriteLine();
            WriteLine("\n----- Изменение значений -----\n");
            sortedAL.ModifySorted(3, 5);
            sortedAL.ModifySorted(-1, 2);
            sortedAL.ModifySorted(2, 4);
            sortedAL.ModifySorted(7, 3);

            foreach (int i in sortedAL)
                Write(i + " ");

            WriteLine();
        }
    }
}
