using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_2
{
    public delegate void ExamDelegate(string str); // делегат
    class Teacher
    {
        public event ExamDelegate examEvent // событие
        {
            add  // добавление метода
            {
                for (int key; ;)
                {
                    key = rnd.Next();
                    if (!sortEvents.ContainsKey(key))
                    {
                        sortEvents.Add(key, value);
                        break;
                    }
                }
            }
            remove // удаление метода
            {
                sortEvents.RemoveAt(sortEvents.IndexOfValue(value));
            }
        }
        public void Exam(string task)
        {
            foreach (var item in sortEvents.Keys)
            {
                if (sortEvents[item] != null)
                    sortEvents[item](task); // функция
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Rayting { get; set; }
        public void Exam(string task)
        {
            WriteLine($"Student {LastName} solved the {task}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> group = new List<Student>
            {
                 new Student {
                 FirstName = "John",
                 LastName = "Miller",
                 BirthDate = new DateTime(1997,3,12),
                 Rayting = 5.6
                 },
                 new Student {
                 FirstName = "Candice",
                 LastName = "Leman",
                 BirthDate = new DateTime(1998,7,22),
                 Rayting = 8.6
                 },
                 new Student {
                 FirstName = "Joey",
                 LastName = "Finch",
                 BirthDate = new DateTime(1996,11,30),
                 Rayting = 10.5
                 },
                 new Student {
                 FirstName = "Nicole",
                 LastName = "Taylor",
                 BirthDate = new DateTime(1996,5,10),
                 Rayting = 3.3
                 }
            };

            Teacher t1 = new Teacher();
            foreach (Student item in group)
            {
                if (item.Rayting > 7.0)
                    t1.examEvent += item.Exam; // 5 подписка на событие
            }

            t1.Exam("Task_1");
        }
    }
}
