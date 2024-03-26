using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class Account
    {
        public delegate void AccountDelegate(string message); // делегат

        // 2
        // AccountDelegate eventAccount; // переменная типа делегата
      
        public event AccountDelegate eventAccount; // создали событие типа делегата

        // 2
        //public event AccountDelegate EventAccount // развернутая форма для него
        //{
        //    add
        //    {
        //        eventAccount += value; // 'value' - методы, кот.вызываем в кач-ве обработчика на событие
        //        Console.WriteLine($"{value.Method.Name} add"); 
        //        // value.Method.Name - имя метода, кот. приставлен к делегату, кот. мы будем подвязывать
        //   }
        //    remove
        //    {
        //        eventAccount -= value; // 'value' - методы, кот.вызываем в кач-ве обработчика на событие
        //        Console.WriteLine($"{value.Method.Name} remove");
        //    }
        //}

        public int Sum { get; set; }
        public Account(int _sum) => Sum = _sum;
        public void Add(int _sum)
        {
            Sum += _sum;
            // Console.WriteLine($"На счет поступило {_sum}. Баланс {Sum} ");
            eventAccount.Invoke($"На счет поступило {_sum}. Баланс {Sum} "); // через 'Invoke' мы отправляем строку, кот. хотим сообщить
            // через наш делегат мы реагируем на событие этого типа делегата
        }
        public void Take(int _sum)
        {
            if (Sum >= _sum)
            {
                Sum -= _sum;
                // Console.WriteLine($"Со счета снято {_sum}. Баланс {Sum}  ");
                eventAccount.Invoke($"Со счета снято {_sum}. Баланс {Sum}  "); // реагируем на событие и как-то сообщаем
            }
            else
                // Console.WriteLine( $"Не хватает денег для снятия. На счету {Sum}");
                eventAccount.Invoke($"Не хватает денег для снятия. На счету {Sum}");
        }
    }

    internal class Program
    {
        static void ShowCons(string str) => Console.WriteLine(str);
        static void ShowConsColor(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.eventAccount += ShowCons;
            account.eventAccount += ShowConsColor;

            account.Add(120);
            Console.WriteLine($"Баланс {account.Sum}");
            account.Take(100);
            Console.WriteLine($"Баланс {account.Sum}");
            account.Take(200);
            Console.WriteLine($"Баланс {account.Sum}");

            Console.WriteLine("************************************");

            // delegate
            Account ac1 = new Account(200);
            ac1.eventAccount += new Account.AccountDelegate(ShowCons); // 1 вариант через делегат создаем
            ac1.eventAccount += ShowCons; // 2 вариант отправляем метод через событие
            ac1.Add(200);

            Console.WriteLine("************************************");

            //анонимный метод
            Account ac2 = new Account(200);
            ac2.eventAccount += delegate (string str) // привязываем новый делегат типа 
            {
                Console.WriteLine(str);
            };
            ac2.Add(200);

            Console.WriteLine("************************************");

            // лямбда-выражения
            Account ac3 = new Account(200);
            ac3.eventAccount += (str) => Console.WriteLine(str);
            ac3.Add(200);

            // add/remove // 2
            //Account ac4 = new Account(200);
            //ac4.EventAccount += ShowCons;
            //ac4.EventAccount += ShowConsColor;
            //ac4.Add(200);
            //ac4.EventAccount -= ShowCons;
            //ac4.EventAccount -= ShowConsColor;
            //ac4.Add(200);
        }
    }
}
