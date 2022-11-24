using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q5
{
    internal class Motor
    {
        private Enum cilindrada { get; set; }
        public enum Cilindrada
        {
            cl10 = 1000,
            cl16 = 1600,
            cl18 = 1800,
            cl20 = 2000,
            cl30 = 3000
        }

        public Motor(Cilindrada cl)
        {
            this.cilindrada = cl;

            //testando ...
            foreach(var valor in Enum.GetValues(typeof(Cilindrada)))
                Console.WriteLine(valor); //??
        }
    }
}