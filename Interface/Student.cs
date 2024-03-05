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

        public bool isStudy = true;

        public bool IsStudy
        {
            get
            {
                return isStudy;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $" {Group}";
        }
        public void Study()
        {
            Console.WriteLine("Студент учится");
        }
    }
}
