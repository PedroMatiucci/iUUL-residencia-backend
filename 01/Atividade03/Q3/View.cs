using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal static class View
    {
        internal static void PrintArmstrong(this int numbers)
        {
            for(int i = 1; i <= numbers; i++)
            {
                if (i.IsArmstrong())
                    Console.WriteLine(i);
            }
        }
    }
}
