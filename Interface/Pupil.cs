using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Pupil : Learning, IStudu
    {
        public string Class_name { get; set; }
        bool isStudy = true;
        public bool IsStudy
        {
            get
            {
                return isStudy;
            }
        }
        public void Study()
        {
            Console.WriteLine("Школьник учится");
        }
        public override string ToString()
        {
            return base.ToString() + $"  {Class_name}";
        }
    }
}
