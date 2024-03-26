using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // потоки
using System.Runtime.Serialization.Formatters.Binary; // BinaryFormatter
using System.Runtime.Serialization.Formatters.Soap; // Soap // нужно добавить ссылку в проекте, если ее нет
using System.Xml.Serialization; // Xml
using System.Text.Json; // Json // подключается через Tools-Nuget Pascage Manager-Manage Nuget Pascage for Solution-System Text Json
// либо через консоль подключить 
// PM>NuGet\Install-Package System.Text.Json

// сериализация - процесс сохранения состояния ниших обьектов в потоке, кот. мы собираемся записывать на внешние файлы
// а затем их восстановление, автоматически сохраняет обьект на внешний файл, сериализуем весь обьект (класс, его поля и тд)
// атрибуты - некие св-ва или меточки для того, чтобы можно было понять, что это за обьект/поле/класс, кот. мы собир-ся сериал-ть

// 4 вида формата:

// 1 // BinaryFormatter // бинарный  (двоичное форматир-ие) - сохраняются не только поля, но и имя каждого типа обьекта
// и имя компановочного блока (удобен, когда нам нужно исп-ть знач-ия об-ов в .NET приложениях) сериализ-ся будут и public и private

// 2 //XML - формат, кот. сохраняет тип неточно (не записывают абсолютные имена типов и компановочных блоков)
// можно исп-ть для любой операц.сис-мы (cross-платформенные), можно работать с любыми приложениями (не только .NET, но и JAVA, QT, базы данных и тд) в любом языке програм-ия
// поэтому не нужно исп-ть точность типов, атрибут 'Seriazible' писать не обяз-но, сериализует все, для всех полей модиф-р доступа только public
// обязат-но должен быть дефолтный кон-р, класс должен быть 'public', если будут 'private', 'protected' поля - то не сериализуются
// Вычисляемые поля не записываются! Константные поля не сериализуются!

// 3 // SOAP - формат, кот. сохраняет тип неточно (не записывают абсолютные имена типов и компановочных блоков)
// можно исп-ть для любой операц.сис-мы (cross-платформенные), можно работать с любыми приложениями (не только .NET, но и JAVA, QT, базы данных и тд) в любом языке програм-ия
// поэтому не нужно исп-ть точность типов. Вычисляемые поля не записываются! Константные поля не сериализуются!

// 4 // JSON - очень распр-ая, удобная, кросс-платформенная, должен иметь либо кон-р без пар-ов,
// либо кон-р, в кот. будут все пар-ры для сериализ-го об-та и они заданы для обьекта (определены)
// поля только public, класс необ-но, вычисляемые поля записываются

namespace Serialized
{
    [Serializable] // для сериализации класса
    // обьявляем тот класс, кот. хотим сериализовать
    public class Student
    {
        // [NonSerialized] // не запишется, исп-ся только к полям
        string MidleName = "MN1";

        const string Group = "PV_322"; // одинаковое поле для всех студентов
        public string FirstName { get; set; } = "Unknow";
        public string LastName { get; set; } = "Unknow";
        public DateTime BD { get; set; }
        public double Rating { get; set; } = 1;
        public int Age
        {
            get { return DateTime.Now.Year - BD.Year; }
        }
        public Student() { } // дефолтный кон-р
        public Student(string fn, string ln, DateTime bd, double rayting) // пишем то, что хотим сериализ-ть
        {
            FirstName = fn;
            LastName = ln;
            BD = bd;
            Rating = rayting;
        }
        public override string ToString() // Object
        {
            return $"{Group,-10} {FirstName,-15}  {LastName,-15} {MidleName,-15} {BD.ToShortDateString(),15} {Age,-5} {Rating,-8} ";
        }
    }
    class Program
    {
        static async Task Main(string[] args) // main меняется на 'async Task Main'
        {
            //создаем обьект для сериализации
            //Student st = new Student
            //{
            //    FirstName = "FN1",
            //    LastName = "LN1",
            //    BD = new DateTime(2020, 01, 01),
            //    Rating = 10.5
            //};

            ////////////////// 1 // BinaryFormatter

            //BinaryFormatter bf = new BinaryFormatter();

            //// опасный процесс, потому что захватываем внешние ресурсы - поэтому 'try-catch'
            //try
            //{
            //    // сериализация
            //    // создаем поток (обьект 'Stream')
            //    using (Stream fs = File.Create("test.bin")) // создаем файл
            //    {
            //        bf.Serialize(fs, st); // через обьект 'fs' в наш файлик 'test.bin' записываем сериализ-ый обьект 'st')
            //    }

            //    Console.WriteLine("Ser_OK");

            //    Console.WriteLine("_____________________________________________________________________________________");

            //    // десериализация // считываем обратно
            //    // выделяем память
            //    Student tmp = null;
            //    using (Stream fs = File.OpenRead("test.bin")) // открываем и читаем
            //    {
            //        tmp = (Student) bf.Deserialize(fs); // т.к. мы работаем с 'Object', нам нужно привести к типу 'Student'
            //        Console.WriteLine(tmp);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////////////////// 2 // SOAP

            //SoapFormatter sf = new SoapFormatter();

            //// опасный процесс, потому что захватываем внешние ресурсы - поэтому 'try-catch'
            //try
            //{
            //    // сериализация
            //    // создаем поток (обьект 'Stream')
            //    using (Stream fs = File.Create("test_2.soap")) // создаем файл
            //    {
            //        sf.Serialize(fs, st); // через обьект 'fs' в наш файлик 'test.bin' записываем сериализ-ый обьект 'st')
            //    }

            //    Console.WriteLine("Ser_OK");

            //    Console.WriteLine("_____________________________________________________________________________________");

            //    // десериализация // считываем обратно
            //    // выделяем память
            //    Student tmp = null;
            //    using (Stream fs = File.OpenRead("test_2.soap")) // открываем и читаем
            //    {
            //        tmp = (Student)sf.Deserialize(fs); // т.к. мы работаем с 'Object', нам нужно привести к типу 'Student'
            //        Console.WriteLine(tmp);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////////////////// 3 // Xml

            // XmlSerializer xs = new XmlSerializer(typeof(Student)); // передавая обьект - указываем его тип

            // 1 // один студент
            //try
            //{
            //    using (Stream fs = File.Create("test_3.xml"))
            //    {
            //        xs.Serialize(fs, st); // принимает поток и обьект
            //        Console.WriteLine(st);
            //    }

            //    Console.WriteLine("_____________________________________________________________________________________");

            //    using (Stream fs = File.OpenRead("test_3.xml")) // открываем и читаем
            //    {
            //        // десериализация // считываем обратно
            //        // выделяем память
            //        Student tmp = null;
            //        tmp = (Student)xs.Deserialize(fs); // т.к. мы работаем с 'Object', нам нужно привести к типу 'Student'
            //        Console.WriteLine(tmp);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // 2 // массив студентов

            // создаем массив студентов
            //List<Student> students = new List<Student>()
            //{
            //    new Student
            //    {
            //    FirstName = "FN1",
            //    LastName = "LN1",
            //    BD = new DateTime(2020, 01, 01),
            //    Rating = 10.5
            //    },
            //     new Student
            //    {
            //    FirstName = "FN2",
            //    LastName = "LN2",
            //    BD = new DateTime(2021, 05, 03),
            //    Rating = 7.5
            //    },
            //      new Student
            //    {
            //    FirstName = "FN3",
            //    LastName = "LN3",
            //    BD = new DateTime(2022, 04, 01),
            //    Rating = 6.5
            //    },
            //};

            //XmlSerializer xs = new XmlSerializer(typeof(List<Student>)); // передавая обьект - указываем его тип

            //try
            //{
            //    using (Stream fs = File.Create("test_4.xml"))
            //    {
            //        xs.Serialize(fs, students); // принимает поток и обьект
            //        Console.WriteLine(students);
            //    }

            //    Console.WriteLine("_____________________________________________________________________________________");

            //    using (Stream fs = File.OpenRead("test_4.xml")) // открываем и читаем
            //    {
            //        // десериализация // считываем обратно
            //        // выделяем память
            //        List<Student> tmp = null; // создаем область памяти
            //        tmp = (List<Student>)xs.Deserialize(fs); // т.к. мы работаем с 'Object', нам нужно привести к типу 'Student'

            //        foreach (Student item in tmp)
            //            Console.WriteLine(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////////////////// 4 // Json 
            // 4.1 RAM

            //Student st = new Student("FN1", "LN1", new DateTime(2020, 01, 01), 10.5);

            //// json-сериализация - это строка, поэтому создадим строку
            //string tmp_st_json = JsonSerializer.Serialize(st);
            //Console.WriteLine(tmp_st_json);

            //Console.WriteLine("_____________________________________________________________________________________");

            //// десериализация
            //Student tmp = JsonSerializer.Deserialize<Student>(tmp_st_json); // нужно указать тип обьекта
            //Console.WriteLine(tmp);

            // 4.2 file
            using (FileStream fs=new FileStream("test_5.json", FileMode.OpenOrCreate))
            {
                Student st = new Student("FN1", "LN1", new DateTime(2020, 01, 01), 10.5);
                //JsonSerializer.Serialize(fs,st); // сериализуем через поток // 1 вариант
                await JsonSerializer.SerializeAsync(fs, st); // 2 вариант

                Console.WriteLine("Ok");
            }

            Console.WriteLine("_____________________________________________________________________________________");

            // десериализация
            using (FileStream fs = new FileStream("test_5.json", FileMode.Open))
            {
                //Student tmp = JsonSerializer.Deserialize<Student>(fs); // нужно указать тип обьекта // 1 вариант
                Student tmp = await JsonSerializer.DeserializeAsync<Student>(fs); // 2 вариант

                Console.WriteLine(tmp);
            }
        }
    }
}
