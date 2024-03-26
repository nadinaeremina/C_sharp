using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Event2
{
    public delegate void ExamDelegate(string str); // делегат с сигнатурами метода // 2
    class Student // подписчики на событие
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Rayting { get; set; }
        // каждый студент выполняет эту задачу
        public void Exam(string task) // обработчик события (те же сигнатуры) // 4
        {
            WriteLine($"Student {LastName} solved the {task}");
        }
    }
    class Teacher // диспетчер (генератор события) 
    {
        SortedList<int, ExamDelegate> sortEvents = new SortedList<int, ExamDelegate>();
        Random rnd = new Random();
        //public event ExamDelegate examEvent; 
        public event ExamDelegate examEvent // событие типа делегата // 3
        {
            add  // добавление метода
            {
                for(int key; ;)
                {
                    key = rnd.Next();
                    if (!sortEvents.ContainsKey(key))
                    {
                        sortEvents.Add(key, value); // 'value' - текущий метод
                        break;
                    }
                }
            }
            remove // удаление метода
            {
                sortEvents.RemoveAt(sortEvents.IndexOfValue(value));
            }
        }
        public void Exam(string task)  // метод события // 1
        {
            foreach (var item in sortEvents.Keys)
            {
                if (sortEvents[item] != null)
                    sortEvents[item](task); // функция (каждый студент подписался)
                // в каждый метод 'Exam' (каждому студенту) мы передаем 'task' (string)
                
            } 
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
                    t1.examEvent += item.Exam; // подписка на событие // 5
                // у каждого обьекта, кот. подписывается на событие должен быть обработчик ('Exam')
            }

            t1.Exam("Task_1"); // вызов обработчика события // 6

            //Student s_new = new Student
            //{
            //    FirstName = "Petr",
            //    LastName = "Petrov",
            //    BirthDate = new DateTime(2000, 5, 10),
            //    Rayting = 9.5
            //};

            //Console.WriteLine("_______________________________");

            //t1.examEvent += s_new.Exam;
            //t1.Exam("Task_2");
        }
    }
}
