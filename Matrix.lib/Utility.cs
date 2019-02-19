using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.lib
{
    public static class Utility
    {
        public static void Swap<T>( ref T a, ref T b )
        {
            var buf = a;
            a = b;
            b = buf;
        }
    }
}
