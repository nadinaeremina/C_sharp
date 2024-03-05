using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Student
    {
        //public string firstName;
        //public string lastName;
        //public int age;
        //public double rating;
        public static string group;

        // развернутые св-ва
        // properties // 'prop' - propfull - 'tab'+'tab' - тип + 'tab' + имя + 'tab'
        // если все св-во 'public', то 'set', 'get' тоже public (public прописывать не нужно)
        // но могут быть 'protected' (прописать можно только к одному из св-в)
        // если мы не хотим, чтобы св-во менялось, то св-во 'set' можно не писать


        //private string firstName;

        //public string FirstName // 'MyProperty' можно назвать по-разному, лучше как поле и с большой буквы
        //{
        //    get { return firstName != null ? firstName: "Не задано"; }
        //    set { firstName = value.ToUpper(); }
        //}

        //private string lastName;

        //public string LastName
        //{
        //    get { return lastName != null ? lastName: "Не задано" ; }
        //    set { lastName = value.ToLower(); }
        //}

        //private int age;

        //public int Age
        //{
        //    get { return age; }
        //    set 
        //    { 
        //        if ( value >= 10 && value <= 60) // проверка
        //        age = value;
        //    }
        //}

        //private double rating;

        //public double Rating
        //{
        //    get 
        //    {   return rating; }
        //    set 
        //    {
        //        if (value > 0 && value < 12)
        //        rating = value; 
        //    }
        //}

        // авто св-ва // без 'get' нельзя // можно присвоить значение по умолчанию - замена дефолтного кон-ра
        public string FirstName { get; set; } = "Unknown"; 
        public string LastName { get; set; } = "Unknown";
        //  public int Age { get; set; } = DateTime.Now.Year < 2020 ? 16 : 26; // можно и так
        public int Age
        {
            get  { return DateTime.Now.Year - BD.Year;}
            set {}
        }

        public double Rating { get; set; } = 1;
        public DateTime BD { get; set; }

        // для статич.поля необ-но делать авто св-ва, можно просто метод 'Set'

        // если исп-ем статич.поле - для него создаем статич.кон-р // поле будет работать для всех об-ов данного класса
        // чтобы поменять значение этого поля - нужно создать метод 'Set' для него
        static Student()
        {
            group = "PD_322";
        }

        //public void SetAge(int _age)
        //{
        //    age = _age;
        //}

        //public int GetAge()
        //{
        //    return age;
        //}

        //public Student()
        //{
        //    firstName = "Unknow";
        //    lastName = "Unknow";
        //    age = 18;
        //    rating = 10.2;
        //}

        // статич.кон-р связан с классом, а не с об-ом, создается для того, чтобы работать с инициализацией статич.полей
        // статич.поле - не меняет значение, для всех экземпляров класса оно одинаковое

        //public Student(string _firstName, string _lastName, int _age, double _rating)
        //{
        //    firstName = _firstName;
        //    lastName = _lastName;
        //    age = _age;
        //    rating = _rating;
        //}

        // если у нас будет такой кон-р, то непроинициализированные поля,
        // если это числовые - будут: 0, если ссылочные пар-ры: null, если логические: false
        //public Student(string _firstName, string _lastName)
        //{
        //    firstName = _firstName;
        //    lastName = _lastName;
        //}

        public static void setGroup(string _group)
        {
            group = _group;
        }

        //public void Show()
        //{
        //    WriteLine($"{firstName,20} {lastName,20} {age,5} {rating,10}");
        //    // вторым аргументом-сколько символов под переменную // заполнение справа налево
        //}

        // вместо метода 'Show' можно перегрузить метод 'ToStrinh' класса 'Object'
        public override string ToString()
        {
            return $"{FirstName,-20} {LastName,-20} {BD.ToShortDateString(),-15} {Age,-20} {Rating,-10} {group}"; // сработает авто св-во 'Get'
            // если у нас авто св-во - в этом методе обращаемся к св-ву, если не авто - то к полю
        }
    }
}
