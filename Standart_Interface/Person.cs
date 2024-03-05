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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BD { get; set; }
        public Passport Passport { get; set; }

        public object Clone()
        {
            Person tmp = (Person)MemberwiseClone(); // показываем кого к какому типу мы клонируем
            tmp.Passport = new Passport { Series = this.Passport.Series, Number = this.Passport.Number };
            return tmp;
        }
        public int CompareTo(object obj)
        {
            if (obj is Person)
                // return LastName.CompareTo(((Person)obj).LastName);
                return LastName.CompareTo((obj as Person).LastName);
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{FirstName,10} {LastName,15} {BD.ToShortDateString(),10} {Passport.Series} {Passport.Number}";
        }
    }

    class Data_person: IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Person && y is Person)
                return DateTime.Compare((x as Person).BD, (y as Person).BD);
            throw new NotImplementedException();
        } 
    }
}
