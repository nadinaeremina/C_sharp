using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_collector
{
    class Garbage
    {
        private int[] _garbage = null;
        public Garbage()
        {
            Random rnd = new Random();
            this._garbage = new int[rnd.Next(1000, 10000)];
            for (int i = 0; i < this._garbage.Length; i++) { this._garbage[i] = rnd.Next(); }
        }
    }
}
