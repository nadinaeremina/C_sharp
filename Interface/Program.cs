using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        // интерфейс - альтернатива абстрактному классу
        // класс наследуем, а интерфейс реализуем
        // позволяет реализовать тому классу, кот.его реал-ет - реал-ть все комп-ты интерфейса 
        // заменяет множественное наследование, не создает обьекты, в классе нет реализации, могут быть поля, но нет кон-ров
        static void Main(string[] args)
        {
            Student s1 = new Student { FirstName = "SN1", LastName = "SLN2", BD = new DateTime(2020, 10, 10), Education = "Step", Year_st = 2, Group = "G1" };
           
            Pupil p1 = new Pupil { FirstName = "SN1", LastName = "SLN2", BD = new DateTime(2020, 10, 10), Education = "School_1", Year_st = 10, Class_name = "G1" };

            Learning[] learnings = { s1, p1 };

            Employee em = new Employee();

            em.ListEmpl = new List<Employee>
            {
            new Worker{FirstName = "W1", LastName = "WLN1", BD = new DateTime(2000,10,10), Post = "Рабочий", Salary = 20000, Position = "склад" },
            new Driver{FirstName = "W1", LastName = "WLN1", BD = new DateTime(2000,10,10), Car_make= "BMW", Salary = 20000, Position = "склад" },
            new Manager{FirstName = "W1", LastName = "WLN1", BD = new DateTime(2000,10,10), FieldActivity = "банк", Salary = 20000, Position = "склад" }
            };

            // обращаемся к интерфейсу, т.к. 'Study' обьявлен в интерфейсе, т.е. мы приводим об-т к общему интерфейсу
            foreach (IStudu item in learnings) // тип интерфейса IStudy (к нему приводим наш массив)
            // все методы, кот.отн-ся к этому массиву - мы увидели
            {
                Console.WriteLine(item);
                item.Study(); // от интерфейса без override
            }

            Console.WriteLine("***************************");

            foreach (IEmployees item in em.ListEmpl) // от интерфейса 
            {
                Console.WriteLine(item);
                item.Work(); // от интерфейса без override
                item.Report();
                item.Rest();
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }

            Console.WriteLine("***************************");

            foreach (Employee item in em.ListEmpl) //  от класса
            {
                Console.WriteLine(item);
                item.Work(); // от родителя с override
                item.Report();
                item.Rest();
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
        }
    }
}
