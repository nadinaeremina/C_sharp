using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_collector
{
    class GarbageHelper
    {
        public void MakeGarbage()
        {
            for (int i = 0; i < 1000; i++) { var p = new Person(); }
        }
        class Person
        {
            private string _name;
            private string _surname;
            private byte _age;
            public Person(string name, string surname, byte age)
            {
                this._age = age;
                this._name = name;
                this._surname = surname;
            }
            public Person(): this("", "", 0) { }
        }
    }
}
