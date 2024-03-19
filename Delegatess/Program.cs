using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegatess
{
    class Program
    {
        // делегаты - это об-ты, кот. указывают на методы - указатели // делегаты - обработчики событий 
        delegate void Delegate_my();
        delegate int Delegate_my1(int n);
        delegate int Delegate_calc1(int a1, int a2);
        delegate T Delegate_calc<T>(T a1, T a2T); // создали шаблонный делегат
        public class Calc_my
        {
            public int Add(int n1, int n2) { return n1 + n2; }
            // public int Sub(int n1, int n2) { return n1 - n2; }
            public double Sub(double n1, double n2) { return n1 - n2; }
            public static int Mult(int n1, int n2) { return n1 * n2; }
            public int Div(int n1, int n2) 
            {
                if (n2 != 0)
                    return n1 / n2;
                else
                    throw new DivideByZeroException();
            }
        }
        static void Main(string[] args)
        {
            Delegate_my d_m; // создали обьект делегата
            void f1() => Console.WriteLine("************f1********"); // лямбда-выражение 
            // void f2() => Console.WriteLine("************f2********"); 
            d_m = f1; // указателю присвоили адрес метода // первый способ
            d_m();
            // d_m = f2;
            // d_m();

            int f2(int n) { Console.WriteLine($"************f2 {n}********"); return n; };
            Delegate_my1 d_m1;
            d_m1 = new Delegate_my1(f2); // указателю присвоили адрес метода // второй способ
            // Delegate_my1 d_m1 = new Delegate_my1(f2); // указателю присвоили адрес метода // третий способ
            int res = d_m1(10);
            Console.WriteLine(res);

            Calc_my calc_My = new Calc_my();
            //try
            //{
            //    char d = Convert.ToChar(Console.ReadLine());
            // Delegate_calc del = null;
            //    switch (d)
            //    {
            //        case '+': del = new Delegate_calc(calc_My.Add); break; // если метод не статич.
            //        case '/': del = new Delegate_calc(calc_My.Div); break; // если метод не статич.
            //        case '*': del = new Delegate_calc(Calc_my.Mult); break; // если метод статич.
            //        case '-': del = calc_My.Sub; break; // можно без 'new'
            //        default: throw new InvalidOperationException();
            //    }
            //    Console.WriteLine($"{del(20,4)}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}  

            Delegate_calc<int> del = null; // раз делегат шаблонный - нужно указать тип
            Delegate_calc<double> delDouble = null; 

            del = calc_My.Add; // делегат стал массивом 
            del += Calc_my.Mult;
            del += calc_My.Div;
            delDouble += calc_My.Sub;

            //foreach (Delegate_calc item in del.GetInvocationList()) // 'GetInvocationList() - перечислитель эл-ов
            //{
            //    Console.WriteLine($"{item(12,4)}"); // 'item' - отдельный делегат
            //    Console.WriteLine("*************");
            //}

            //del -= calc_My.Div;
            //Console.WriteLine("************* ------- ************");

            //foreach (Delegate_calc item in del.GetInvocationList()) // 'GetInvocationList() - перечислитель эл-ов
            //{
            //    Console.WriteLine($"{item(12, 4)}"); // 'item' - отдельный делегат
            //    Console.WriteLine("*************");
            //}

            foreach (Delegate_calc<int> item in del.GetInvocationList()) // 'GetInvocationList() - перечислитель эл-ов
            {
                Console.WriteLine($"{item(12, 4)}"); // 'item' - отдельный делегат
                Console.WriteLine("*************");
            }

            //Console.WriteLine("************* ------- ************");

            foreach (Delegate_calc<double> item in delDouble.GetInvocationList()) // 'GetInvocationList() - перечислитель эл-ов
            {
                Console.WriteLine($"{item(12.5, 4.3)}"); // 'item' - отдельный делегат
                Console.WriteLine("*************");
            }

            Delegate_calc1 del1 = calc_My.Add;
            Delegate_calc1 del2 = calc_My.Div;
            Delegate_calc1 del3 = del1 + del2; // можно сложить 2 делегата (если у них одинаковая сигнатура)

            foreach (Delegate_calc1 item in del3.GetInvocationList())
            {
                Console.WriteLine($"{item(12,4)}");
                Console.WriteLine("*************");
            }
        }
    }
}
