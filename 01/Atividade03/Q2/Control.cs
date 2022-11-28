using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class Control
    {
        public static void Start()
        {
            string txt = IndiceRemissivo.ReadTxt();
            string? ignore = IndiceRemissivo.ReadIgnore();

            IndiceRemissivo.Imprime(txt, ignore);
        }
    }
}
