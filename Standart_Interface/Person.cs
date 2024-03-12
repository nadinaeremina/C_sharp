using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standart_Interface
{
    class Person: IComparable, ICloneable 
    {
        // у 'IComparable' единственный метод 'CompareTo'
        // у 'ICloneable' единственный метод 'Clone'
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BD { get; set; }
        public Passport Passport { get; set; }
        public object Clone()
        {
            Person tmp = (Person)MemberwiseClone(); // показываем кого к какому типу мы клонируем
            // если присутствуют ссылочные типы - нужно прописать подробное копирование
            tmp.Passport = new Passport { Series = this.Passport.Series, Number = this.Passport.Number };
            return tmp; // 'Clone' возвращает нам обьект
        }
        public int CompareTo(object obj) // второй такой метод не получится сделать, т.к. он тоже должен принимать 'object'
        {
            if (obj is Person)
                // return LastName.CompareTo(((Person)obj).LastName);
                return LastName.CompareTo((obj as Person).LastName); // сравниваем два 'Last Name'
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{FirstName,10} {LastName,15} {BD.ToShortDateString(),10} {Passport.Series} {Passport.Number}";
        }
    }
    class Data_person: IComparer // перегруженный метод
    {
        public int Compare(object x, object y) // реализация об-на с интерфейсом 'IComparer'
        {
            if (x is Person && y is Person)
                return DateTime.Compare((x as Person).BD, (y as Person).BD);
            throw new NotImplementedException();
        } 
    }
    class Passport_Person : IComparer // перегруженный метод
    {
        public int Compare(object x, object y)
        {
            if (x is Person && y is Person)
            {
                int ser_passport = ((Person)x).Passport.Series.CompareTo(((Person)y).Passport.Series);
                if (ser_passport == 0) return ((Person)x).Passport.Number.CompareTo(((Person)y).Passport.Number);
                else return ser_passport;
            }
            throw new NotImplementedException();
        }
    }
}
