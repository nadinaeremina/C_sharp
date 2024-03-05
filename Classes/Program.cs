using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Classes
{
    // public - 
    // protected - 

    // private - доступ разрешен внутри класса и тем, кому мы разрешили дружбу
    // (м/у классами, м/у ф-цией и отдельными полями класса - через методы)
    // разрешаем 'Friend', а потом даже если поле приватное - мы с ним работаем

    // internal - данные, доступные только в методах текущей сборки

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "fddsf"; // заголовок
            BackgroundColor = ConsoleColor.Red; // задний фон
            ForegroundColor = ConsoleColor.Yellow; // цвет текста
            ResetColor(); // сбросить настройки цветов

            //SetWindowSize(60, 40); // принимает ширину экрана и высоту // 60 символов и 10 строк
            //SetBufferSize(60, 50);
            //SetWindowPosition(20,20);

            Student s1 = new Student(); // 's1' хранит адрес, где лежат поля(поля лежат в другой ячейке по этому адресу)
            //s1.firstName = "FN1";
            //s1.lastName = "LN1";
            //s1.age = 20;
            //s1.rating = 10.5;
            //s1.Show();
            // WriteLine(s1);

            //Student s2 = new Student("hft", "ghdgfdh", 29, 2.5);
            //WriteLine(s2);

            Student.setGroup("PV_321");
            //Student s3 = new Student("hgfh", "tghydghtfd", 17, 3.8);
            //WriteLine(s3);

            // s1.SetAge(23); // метод 'Set'

            //Student s4 = new Student();
            //s4.FirstName = ReadLine(); // св-вo 'set'
            //// WriteLine(s4.Age); // св-вo 'get'
            //s4.Age = int.Parse(ReadLine());
            //s4.Rating = double.Parse(ReadLine());
            //WriteLine(s4);

            Student s5 = new Student { FirstName = "Ella", LastName = "Chornogor", BD = new DateTime(2018, 12, 23), Rating = 5.5 };
            WriteLine(s5);
        }
    }
}
