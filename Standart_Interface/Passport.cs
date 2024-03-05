using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standart_Interface
{
    class Passport
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"{Series,5} {Number,8}";
        }
    }
}
