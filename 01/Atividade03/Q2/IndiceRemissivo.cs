using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class IndiceRemissivo
    {
        public static string ReadTxt()
        {
            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\texto.txt");
            return reader.ReadToEnd();
        }
        public static string? ReadIgnore()
        {
            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\ignore.txt");
            return reader.ReadToEnd();
        }

        public static void Imprime(string txt, string? ignore)
        {
            string[] ignorewords = ignore.Split('\n');
            string[] words = txt.Split(' ');
            Array.Sort(words);

            //??
        }
    }
}
