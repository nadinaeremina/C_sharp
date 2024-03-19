using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// в 'try' - проверяем код, в 'catch' - реакция на ошибку // 'catch' могут быть перегружены по типу своих пар-ов
// 'throw' - вбрасываем явную генерацию искл-ия
// finally - сработает в любой ситуации, чаще всего помещают код, кот.исп-ся д/очистки неуправляемых ресурсов (подключение к внешним файлам)
// 'try' и 'finally' можно исп-ть без 'catch', но лучше с ним

// SystemException - станд.исключения, генерируются самой средоя языка 'C'
// ApplicationException - искл-ия, созданные разработчиком
// конкретный 'catch' лучше в начало, а станд. 'catch' лучше в конец // лучше делать конкретные 'catch'

// 'checked'
// 'unchecked'
// 'OverFlowexception' - ошибка, н-р: переполнение типа (разрядности)

namespace ConsoleApp1
{
    // 1

    //public class Exception_my : ApplicationException
    //{
    //    private string message { get; set; } // переопределим 'message'
    //    public DateTime Ex_time { get; private set; } // переменная, кот.определяет время создания ошибки
    //    public Exception_my() // кон-р
    //    {
    //        message = "My exception";
    //        Ex_time = DateTime.Now;
    //    }
    //}

    // 2

    public class Exception_my : ApplicationException
    {
        public DateTime Ex_time { get; private set; }
        public Exception_my() : base("My_exception") // взяли кон-р базового класса, переопределили 'message'
        {
            Ex_time = DateTime.Now;
        }
    }

    //3 

    //[Serializable] // обязат. атрибут
    //public class MyException : Exception // можно наследоваться от самого базового класса 'Exception'
    //{
    //    public MyException() { } // кон-р дефолтный
    //    public MyException(string message) : base(message) { } // перегруженный кон-р для 'message'
    //    public MyException(string message, Exception inner) : base(message, inner) { } // перегруженный кон-р для обр-ки собств.искл-ий
    //    protected MyException(
    //      System.Runtime.Serialization.SerializationInfo info,
    //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { } // перегруженный кон-р, кот. вып-ет сериализацию типа
    //}

    class Program
    {
        static int My_function(int _n1, int _n2)
        {
            int res = 0;
            try
            {
                res = _n1 / _n2;
                WriteLine("++++++++++++after func++++++++++");
            }
            catch (DivideByZeroException de)
            {
                // 1
                // WriteLine("++++++++++++catch function++++++++++");
                // throw; // подбрасываем искл-ие, оно передается в след. 'catch' (в 'main')

                // 2
                throw new Exception("++++++++++++catch function++++++++++", de);
            }
            return res;
        }

        static void f2()
        {
            throw new Exception("MyException");
        }
        static void f1()
        {
            f2();
        }
        static void f()
        {
            try
            {
                f1();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                WriteLine($"Stack trace:\n {e.StackTrace}"); 
                // 'StackTrace' - это св-во дает нам инф-ию об обр-ке искл-ия, включая метод его сгенерировавший 
                // стек вызовов методов, кот. были зависимы друг от друга
            }
        }

        static void Main(string[] args)
        {
            int n1, n2, res = 0;

            // 1

            //try
            //{
            //    n1 = int.Parse(ReadLine());
            //    n2 = int.Parse(ReadLine());
            //    res = n1 / n2;
            //    if (res > 10)
            //        throw new Exception_my();
            //    WriteLine(res);
            //}
            //// наши 'catch' отл-ся типами данных, типами 'throw'
            //// универ-ый 'Exception' принимает любой тип, любая ошибка попадет сюда
            //catch (Exception_my me) 
            //{
            //    WriteLine(me.Message);
            //    WriteLine(me.Ex_time);
            //}
            //catch (Exception ex)
            //{
            //    WriteLine(ex.Message);
            //}
            //finally
            //{
            //    WriteLine("**********");
            //}


            // 2

            //try
            //{
            //    WriteLine("+++++++ 1 +++++++");
            //    throw new Exception("Мама мыла раму");
            //    WriteLine("+++++++ 2 +++++++");
            //}
            //catch(Exception me)
            //{
            //    WriteLine(me.Message);
            //}
            //finally
            //{
            //    WriteLine("++++++ ALL ++++++");
            //}

            // 3

            //try
            //{
            //    WriteLine("+++++++ 1 +++++++");
            //    throw new Exception_my();
            //    WriteLine("+++++++ 2 +++++++"); // это мы никогда не увидим
            //}
            //catch (Exception me)
            //{
            //    WriteLine(me.Message); // 'Message' вызовется от 'Exception_my' - потому что мы унаследовались
            //}
            //finally
            //{
            //    WriteLine("++++++ ALL ++++++");
            //}

            // 4

            // 'try' и 'catch' разрывать нельзя, 'catch' и 'finally' тоже
            //string str = null;
            //try
            //{
            //    n1 = int.Parse(ReadLine());
            //    n2 = int.Parse(ReadLine());
            //    res = n1 / n2; // если здесь ошибки не произойдет - след.строка сработает
            //    str = "Проверка данных";
            //    WriteLine(res);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    WriteLine(ex.Message);
            //}
            //finally
            //{
            //    WriteLine("**********");
            //}
            //// если в 'try' не произощло ошибки - продолжаем работу, будем проверять строку
            //WriteLine(str.Contains(" успешна"));

            // 5 

            // повторное генерирование искл-ий
            //try
            //{
            //    WriteLine("++++++++++++before func++++++++++");
            //    n1 = int.Parse(ReadLine());
            //    n2 = int.Parse(ReadLine());
            //    res = My_function(n1, n2);
            //    WriteLine(res);
            //    WriteLine("++++++++++++after main++++++++++");
            //}
            //catch (Exception me)
            //{
            //    // 1
            //    // WriteLine("++++++++++++catch main++++++++++");

            //    WriteLine(me.Message);

            //    // 2
            //    WriteLine(me.InnerException.Message);
            //}

            // 6

            //f(); // StackTrace

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // 1 байт - это 8 разрядов, 2^8 степени может поместить чисел (255)
            //byte b = 100; //255
            //b = (byte)(b + 200); //300 - здесь уже переполнение
            //WriteLine(b);

            //int n = 65536; //4 байта, 32 бита 2^32
            //short h = (short)n; //2 байта, 16 бит 2^16
            //WriteLine(h);

            // b = 255;

            // 1

            //try
            //{
            //    // контролируем режим переполнения
            //    checked // сгенерируется 'OverFlowException'
            //    {
            //        b++; // здесь мб переполнение, поэтому берем в блок 'checked'
            //    }
            //    WriteLine(b);
            //}
            //catch (OverflowException e) // ошибка этого типа
            //{
            //    WriteLine(e.Message);
            //}

            // 2

            //try
            //{
            //    unchecked // проигнорируется 'OverFlowException', работаем с тем, что получится (не очень правильно)
            //    {
            //        b++;
            //    }
            //    WriteLine(b);
            //    WriteLine("+++++");
            //}
            //catch (OverflowException e)
            //{
            //    WriteLine(e.Message);
            //}

            // 3

            //byte b = 100;
            //WriteLine(unchecked((byte)(b + 200))); // b = 44
            //try
            //{
            //    WriteLine(checked((byte)(b + 200))); // генерация иск-ия
            //}
            //catch (OverflowException oe)
            //{
            //    WriteLine(oe.Message);
            //}
        }
    }
}

