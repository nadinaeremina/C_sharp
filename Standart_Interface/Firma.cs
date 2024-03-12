using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standart_Interface
{
    class Firma: IEnumerable // осуществляет корректный перебор обьектов в коллекции // System.Collection
    {
        Person[] persons =
            {
            new Person
            {
                FirstName="F1", LastName="L1", BD=new DateTime(2000,10,12),
                Passport=new Passport{Series="AA", Number=113511}
            },
            new Person
            {
                FirstName="F2", LastName="L2", BD=new DateTime(2010,11,2),
                Passport=new Passport{Series="AB", Number=114511}
            },
            new Person
            {
                FirstName="F3", LastName="L3", BD=new DateTime(2008,11,6),
                Passport=new Passport{Series="AA", Number=112311}
            },
            new Person
            {
                FirstName="F4", LastName="L4", BD=new DateTime(2001,9,5),
                Passport=new Passport{Series="AF", Number=118911}
            },
            new Person
            {
                FirstName="F5", LastName="L5", BD=new DateTime(2005,2,4),
                Passport=new Passport{Series="AD", Number=781111} }
            };
        public IEnumerator GetEnumerator() // реализуем для 'IEnumerable'
        {
            return persons.GetEnumerator(); // кого мы будем перебирать в коллекции
        }
        public void Sort()
        {
            Array.Sort(persons); // вызываем метод 'Sort' из под нашего родителя
        }
        public void Sort(IComparer com)
        {
            Array.Sort(persons, com);
        }
    }
}
