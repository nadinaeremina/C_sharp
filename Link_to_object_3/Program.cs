using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link_to_object_3
{
    class Student
    {
        public string FN { get; set; }
        public string LN { get; set; }
        public DateTime BD { get; set; }
        public override string ToString()
        {
            return $"{FN,-15} {LN,-15} {BD.ToShortDateString(),-20} ";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student{FN="FN2", LN="LN2", BD=new DateTime(2020, 2, 12)},
                new Student{FN="FN4", LN="LN4", BD=new DateTime(2014, 4, 11)},
                new Student{FN="FN1", LN="LN1", BD=new DateTime(2002, 3, 10)},
                new Student{FN="FN6", LN="LN6", BD=new DateTime(2009, 1, 9)},
                new Student{FN="FN3", LN="LN3", BD=new DateTime(2012, 5, 8)},
                new Student{FN="FN7", LN="LN7", BD=new DateTime(2013, 7, 17)},
                new Student{FN="FN9", LN="LN9", BD=new DateTime(2007, 9, 6)},
                new Student{FN="FN5", LN="LN5", BD=new DateTime(2000, 6, 5)},
            };

            // 1
            //var query = from s in students
            //            where (DateTime.Now.Year - s.BD.Year) < 14
            //            select s;

            //foreach (var item in query)
            //    Console.WriteLine(item);

            //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");

            //// 2
            //// расширяющие методы, в кач-ве пар-ра принимающие делегат ('Where' и 'Select')
            //var query1 = students.Where(s => (DateTime.Now.Year - s.BD.Year) < 14).Select(s => s);
            //// отбери мне студента, у кот. будет такая разница в возрасте и покажи мне этого студента

            //foreach (var item in query1)
            //    Console.WriteLine(item);

            //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");

            // 3 max
            var query = from s in students
                        where s.BD==
                        (from bd in students // находим в массиве студентов
                         select bd.BD).Max() // значение 'BD', кот. максим-ое
                        select s;
            // будет происходить перебор наших данных по 'BD', перезаписываем - сравниваем, если больше - перекладываем

            foreach (var item in query)
                Console.WriteLine(item);

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");
        }
    }
}
