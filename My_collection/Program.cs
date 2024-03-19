using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace My_collection
{
    class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Фамилия: {LastName}, Имя: {FirstName},Родился: { BirthDate.ToLongDateString()}";
        }
        public override int GetHashCode() // переопределяем метод, чтобы по хэш-коду можно было обьед-ть
        {
            return ToString().GetHashCode();
        }
    }
    class Program
    {
        static Hashtable group = new Hashtable 
        {
            // ключ - класс 'Student', значение - 'ArrayList' (список наших оценок)
            {
            new Student {
                         FirstName ="John",
                         LastName ="Miller",
                         BirthDate =new DateTime(1997,3,12)
                        },
            new ArrayList{ 4,8,6 } 
            },
            {
            new Student { 
                         FirstName ="Candice",
                         LastName ="Leman",
                         BirthDate =new DateTime(1998,7,22)
                        }, 
            new ArrayList { 10,8,4 }
            }
        };
        static void RatingsList()
        {
            WriteLine("+++++++++++++ Список студентов с оценками++++++++++\n");
            foreach (Student student in group.Keys)
            {
                Write($"{student}: ");

                foreach (int item in (group[student] as ArrayList))
                    Write($"{item} ");

                WriteLine();
            }
        }
        static void SetRating(string name, int mark)
        {
            WriteLine($"\n+++++++++++++ Студент {name} получил оценку {mark} ++++++\n");
            foreach (Student item in group.Keys)
            {
                if (item.LastName == name)
                    (group[item] as ArrayList).Add(mark);
            }
        }
        static void Main(string[] args)
        {
            RatingsList();
            SetRating("Leman", 11);
            RatingsList();
        }
    }
}
