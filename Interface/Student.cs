using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Student : Learning, IStudu
    {
        public string Group { get; set; }
        public bool isStudy = true; // описываем св-во
        public bool IsStudy // описываем св-во
        {
            get
            {
                return isStudy;
            }
        }
        public void Study()
        {
            Console.WriteLine("Студент учится");
        }
        public override string ToString()
        {
            return base.ToString() + $" {Group}";
        }
    }
}
