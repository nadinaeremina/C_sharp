using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void AccountDelegate(string message);
    public class Account
    {
        int sum;
        AccountDelegate del; // обьявили делегат (указатель на функцию)
        public void Reg_deleg(AccountDelegate _del) // принимаем делегат (указатель на функцию)
        {
            // del = _del;
            del += _del; // связали делегат с конкретным действием // на наш делегат навешиваем указатель (делегат становится массивом указателей)
        }
        public void UnReg_deleg(AccountDelegate _del)
        {
            del -= _del; // связали делегат с конкретным действием
        }
        public Account(int sum) => this.sum = sum;
        public void Add(int sum) => this.sum += sum;

        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // Console.WriteLine($"Со счета снято: {sum} ");
                del.Invoke($"Со счета снято: {sum} ");
            }
            else
                // del($"Не хватает денег для снятия. На счету: {sum} ");
                del.Invoke($"Не хватает денег для снятия. На счету: {sum} "); // вызываем выполнение этого действия 
        }
    }
    class Program
    {
        static int b = 100;
        delegate void Del();
        delegate void Del_1(string str);
        delegate int Sum(int n1, int n2);
        delegate void Suma(int n1, int n2);
        delegate int Suma_int(int n1, int n2);

        static void ShowMes(string str, Del_1 d)
        {
            d(str);
        }

        static Sum s = delegate (int a1, int a2) // создаем делегат навешиваем на него анонимный метод, имени нет, тело есть
        {
            return a1 + a2 + b;
        };
      
        static void Main(string[] args)
        {
            Account account = new Account(200);

            account.Reg_deleg(PrintSimpleMessage);
            account.Reg_deleg(PrintColorMessage);

            account.Take(100);
            account.Take(150);

            Console.WriteLine("***********************************");

            account.UnReg_deleg(PrintColorMessage);
            account.Take(50);

            Console.WriteLine("***********************************");

            void PrintSimpleMessage(string message) => Console.WriteLine(message);
            void PrintColorMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            // анонимные методы (делегаты) // если метод нужен только один раз
            // 1
            // delegate (par) {тело}

            Del_1 d1 = delegate (string message) // присваиваем делегату указатель на метод без имени, но с телом
            {
                Console.WriteLine(message);
            };
            d1("Мама мыла раму");

            Console.WriteLine("***********************************");

            // 2
            ShowMes("Hello, World!", delegate (string str) { Console.WriteLine(str); });

            Console.WriteLine("***********************************");

            // 3
            int res = s(4, 5);
            Console.WriteLine(res);

            Console.WriteLine("***********************************");

            // лямбда-выражение

            // (par) => { тело}
            // без приним. пар-ов
            Del d = () => Console.WriteLine("tfdhtfhr"); // создали делегат, сразу навесили метод (лямбду-выражение)
            d();

            Console.WriteLine("***********************************");

            // с приним. пар-ми без возвращ. знач-ия
            Suma ss = (a1, a2) => Console.WriteLine($" {a1} + {a2} =  {a1 + a2}");
            ss(4, 5);
            ss(48, 500);

            Console.WriteLine("***********************************");

            // с приним. пар-ми и с возвращ. знач-ем
            Suma_int s1 = (int x1, int x2) => x1 + x2;
            res = s1(45, 75);
            Console.WriteLine(res);

            Console.WriteLine("***********************************");

            Suma_int func = (int x1, int x2) =>
            {
                if (x2 != 0)
                    return x1 / x2;
                else
                    return 0;
            };

            res = func(10, 5);
            Console.WriteLine(res);

            res = func(10, 0);
            Console.WriteLine(res);
        }
    }
}
