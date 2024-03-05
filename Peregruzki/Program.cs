using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace My_drob
{
    abstract class Figure
    {
        public abstract void Draw();
    }
    abstract class Quadrangle : Figure { }
    class Rectangle : Quadrangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public static implicit operator Rectangle(Square s) // безопасное преобразование
        {
            return new Rectangle { Width = s.Length * 2, Height = s.Length };
        }

        public override void Draw()
        {
            for (int i = 0; i < Height; i++, WriteLine())
            {
                for (int j = 0; j < Width; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }

        public override string ToString()
        {
            return $"Rectangle: Width = {Width}, Height = {Height}";
        }
    }
    class Square : Quadrangle
    {
        public int Length { get; set; }
        public static explicit operator
        Square(Rectangle rect)
        {
            return new Square { Length = rect.Height };
        }
        public static explicit operator int(Square s)
        {
            return s.Length;
        }
        public static implicit operator Square(int number)
        {
            return new Square { Length = number };
        }
        public override void Draw()
        {
            for (int i = 0; i < Length; i++, WriteLine())
            {
                for (int j = 0; j < Length; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }
        public override string ToString()
        {
            return $"Square: Length = {Length}";
        }
    }
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }
        public Fraction(int n, int d)
        {
            Numerator = n;
            Denominator = d;
        }
        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            //Fraction tmp = new Fraction();
            //tmp.Numerator = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
            //tmp.Denominator = a.Denominator * b.Denominator;
            //return tmp;

            return new Fraction
            {
                Numerator = a.Numerator * b.Denominator + a.Denominator * b.Numerator,
                Denominator = a.Denominator * b.Denominator
            };
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction tmp = new Fraction();
            tmp.Numerator = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
            tmp.Denominator = a.Denominator * b.Denominator;
            return tmp;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction tmp = new Fraction();
            tmp.Numerator = a.Numerator * b.Numerator;
            tmp.Denominator = a.Denominator * b.Denominator;
            return tmp;
        }
        public static Fraction operator *(Fraction a, int n)
        {
            a.Numerator *= n;
            a.Denominator *= n;
            return a;
        }
        public static Fraction operator *(int n, Fraction a)
        {
            a.Numerator *= n;
            a.Denominator *= n;
            return a;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction tmp = new Fraction();

            if (b.Denominator != 0)
            {
                tmp.Numerator = a.Numerator * b.Denominator;
                tmp.Denominator = a.Denominator * b.Numerator;
                return tmp;
            }
            return tmp;
        }
        public static Fraction operator ++(Fraction a) //перегрузка одна на постфиксный и префиксный декремент
        {
            //return new Fraction
            //{
            //    Numerator = a.Numerator++,
            //    Denominator = a.Denominator++
            //};
            a.Numerator++;
            a.Denominator++;
            return a;
        }
        // следующие два метода необ-мы всегда, когда мы собираемся перегружать операторы сравнения
        public override bool Equals(object obj) // переопределяем метод 'Equals' у себя в классе
        // для того, чтобы нам сравнивать не адреса, а содержимое 
        {
            return this.ToString() == obj.ToString();
        }
        // следующий метод необ-мо переопределять вместе с методом 'Equals'
        public override int GetHashCode() // каждому об-ту дается свой хэш-код
        {
            return this.ToString().GetHashCode();
        }
        // методы сравнения
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }
    }
    internal class Program
    {
        class CDrob // ссылочный тип
        {
            public int Ch { get; set; }
            public int Zn { get; set; }
        }
        struct SDrob // значимый тип
        {
            public int Ch { get; set; }
            public int Zn { get; set; }
        }
        static void Main(string[] args)
        {
            //Fraction f1 = new Fraction { Numerator = 2, Denominator = 3 };
            //Fraction f2 = new Fraction { Numerator = 4, Denominator = 9 };
            //Fraction rez = f1 + f2;
            //WriteLine(rez);

            //WriteLine(f2++); // одинаково
            //WriteLine(++f2); // одинаково

            //WriteLine("*******************");

            //f1 *= 10;
            //WriteLine(f1);

            //Fraction f3 = new Fraction();
            //f3 = 10 * f3;
            //WriteLine(f3);

            //CDrob cd1 = new CDrob { Ch = 2, Zn = 3 };
            //CDrob cd2 = new CDrob { Ch = 2, Zn = 3 };

            //CDrob cd3 = cd2; // поверхностное копирование, копируем ссылку

            // проверяет, указывают ли ссылки на один и тот же рез-т
            //WriteLine(ReferenceEquals(cd1, cd2)); // false
            //WriteLine(ReferenceEquals(cd3, cd2)); // true


            //SDrob sd11 = new SDrob { Ch = 2, Zn = 3 };
            //SDrob sd22 = new SDrob { Ch = 2, Zn = 3 };

            //WriteLine(ReferenceEquals(sd11, sd11)); // false // копия обьекта нах-ся уже по другому адресу
            // а здесь, передавая пар-ры в ф-цию - мы создаем копии

            // 'Equals' выполняет проверку равенства ссылок
            //WriteLine(Equals(cd1, cd2)); // false // передаем ссылочные пар-ры, поэтому 'Equals' будет работать здесь как 'Referenceequals'

            //WriteLine(Equals(sd11, sd22)); // true // в структурах сравнивает значения, т.к. это значимый тип

            //WriteLine(f1 == f2);

            // из произвольного типа в собственный 
            // из собственного в произвольный

            // 'implicit' - безопасное неявное преобразование
            // 'explicit' = явное преобразование (возможна потеря данных) int-short, double-int, знаковый-в беззнаковый

            Rectangle rectangle = new Rectangle
            {
                Width = 5,
                Height = 10
            };
            Square square = new Square { Length = 7 };
            Rectangle rectSquare = square;
            WriteLine($"Неявное преобразование квадрата ({square}) к прямоугольнику.{rectSquare}\n");

            //rectSquare.Draw();

            Square squareRect = (Square)rectangle;
            WriteLine($"Явное преобразование прямоугольника ({rectangle}) к квадрату.{squareRect}\n");

            //squareRect.Draw();

            WriteLine("Введите целое число.");
            int number = int.Parse(ReadLine());
            Square squareInt = number;
            WriteLine($"Неявное преобразование целого ({number}) к квадрату.{squareInt}\n");

            //squareInt.Draw();

            number = (int)square;
            WriteLine($"Явное преобразование квадрата ({square}) к целому.{number}");
        }
    }
}
