using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates2
{
    // применение обобщенных (generics) стандартных делегатов (шаблонных)

    // 1) Action <T> - void, принимает до 16 пар-ов, исп-ся при вызове методов станд. классов,
    // кот находятся в пр-ве 'System' // List<T> - Foreach() 

    // 2) Func <TResult> - T, принимает до 16 пар-ов, исп-ся там, где мы исп-ем 'Enumerable'
    // Select<TSource, TResult> - формир-ся результир-ся послед-ть, требует 'return'

    // 3) Predicat<T> - обобщенный, принимает один пар-р, возвращает 'bool', исп-ся в 'Array', 'List'
    // чаще всего исп-ся метод FindAll' - получить эл-т, кот. соотв-ет конкретному критерию

    // 4) Comparison <T> - обобщенный, сортирует, принимает 2 пар-ра, возвращает 'int'(отрицат, положит или 0)
    // исп-ся с методом Sort(Comparision) - 'Comparision' - в кач-ве пар-ра

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{LastName,-15} {FirstName,15} {BirthDate.ToShortDateString(),-10}";
        }
    }
    class Program
    {
        //1
        //static void FullName(Student student)
        //{
        //    Console.WriteLine($" {student.LastName,-15}\t{student.FirstName,15}");
        //}

        //2
        static string FullName(Student student)
        {
            return $" {student.LastName,-15}\t{student.FirstName,15}";
        }

        //3
        static bool FindAge(Student st)
        {
            return st.BirthDate.Year >= 1997;
        }

        //4
        static int Sort_BD(Student s1, Student s2)
        {
            return s1.BirthDate.CompareTo(s2.BirthDate);
        }

        static void Main(string[] args)
        {
            List<Student> group = new List<Student>
            {
                                new Student {
                                FirstName = "John",
                                LastName = "Miller",
                                BirthDate = new DateTime(1997,3,12)
                                },
                                new Student {
                                FirstName = "Candice",
                                LastName = "Leman",
                                BirthDate = new DateTime(1998,7,22)
                                },
                                new Student {
                                FirstName = "Joey",
                                LastName = "Finch",
                                BirthDate = new DateTime(1996,11,30)
                                },
                                new Student {
                                FirstName = "Nicole",
                                LastName = "Taylor",
                                BirthDate = new DateTime(1996,5,10)
                                }
            };
            Console.WriteLine("List of students:");

            // 1
            //group.ForEach(FullName); // 'ForEach' - наш делегат, которому мы присвоили метод 'FullName'

            // 2
            //IEnumerable<string> students = group.Select(FullName);
            //foreach (string student in students)
            //    Console.WriteLine(student);

            Console.WriteLine("********************************************");

            // 3
            List<Student> l_1997 = group.FindAll(FindAge);
            foreach (Student student in l_1997)
                Console.WriteLine(student);

            Console.WriteLine("********************************************");

            //4
            group.Sort(Sort_BD);
            foreach (Student student in group)
                Console.WriteLine(student);
        }
    }
}
