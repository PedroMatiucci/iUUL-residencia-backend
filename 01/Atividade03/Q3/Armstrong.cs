using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal static class Armstrong
    {
        internal static bool IsArmstrong(this int number)
        {
            var numberstr = number.ToString();
            var houses = numberstr.Length;
            var single = numberstr.ToCharArray();

            double sum = 0;
            foreach (var numchar in single)
            {
                var num = int.Parse(numchar.ToString());
                sum += Math.Pow(num,houses);
            }
            if (sum == number) return true; else return false;
        }
    }
}
