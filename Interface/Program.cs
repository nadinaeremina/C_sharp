using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
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

            foreach (IStudu item in learnings) // тип интерфейса IStudy
            {
                Console.WriteLine(item);
                item.Study(); // от интерфейса без override
            }

            foreach (IEmployees item in em.ListEmpl) // и от интерфейса и от класса
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
