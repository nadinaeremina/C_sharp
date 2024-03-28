using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_to_object_2
{
    class Student
    {
        public string FN { get; set; }
        public string LN { get; set; }
        public int GroupID { get; set; }
    }
    class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // многотабличные запросы, когда есть несколько таблиц, между собой связанных каким-то полем (GroupID и ID)

            List<Group> groups = new List<Group>
            {
                new Group {ID = 1, Name = "PV-322"},
                new Group {ID = 2, Name = "PV-323"},
            };

            List<Student> students = new List<Student>
            {
                new Student{FN="FN2", LN="LN2", GroupID=1},
                new Student{FN="FN4", LN="LN4", GroupID=1},
                new Student{FN="FN1", LN="LN1", GroupID=2},
                new Student{FN="FN6", LN="LN6", GroupID=1},
                new Student{FN="FN3", LN="LN3", GroupID=2},
                new Student{FN="FN7", LN="LN7", GroupID=2},
                new Student{FN="FN9", LN="LN9", GroupID=1},
                new Student{FN="FN5", LN="LN5", GroupID=1},
            };

            // 1
            IEnumerable<Student> query = from g in groups // берем эл-т из кол-ции 'group'
                                        join st in students on g.ID equals st.GroupID // соединяем с эл-ми из кол-ции 'students'
                                        // 'join' - соединение по ключу // 'on' - что с чем должно совпадать // 'equals' - оператор сравнения
                                        into res // получаем рез-т (кол-ция)
                                        from r in res  
                                        select r; // покажи нам отдельный обьект из рез-та отбора

            foreach  (Student item in query)
                Console.WriteLine($"{item.FN, -10} {item.LN, -10} {groups.First(g=>g.ID==item.GroupID).Name, -15}");
                // 'First' предикат - возвращает первый эл-т послед-ти, удовлет. указанному условию
                // если у нашего эл-та 'Group' поле ID соответствует полю 'GroupID' у второго эл-та - возвращает этот эл-т

            Console.WriteLine("*****************************************************************");

            // 2 
            var query_1 = from g in groups
                          join st in students on g.ID equals st.GroupID
                          select new // создаем новый обьект
                                    {
                                        FN = st.FN,
                                        LN = st.LN,
                                        GroupName = g.Name
                                    };

            foreach (var item in query_1)
                Console.WriteLine($"{item}");
        }
    }
}
