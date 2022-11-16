using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Piramide
    {
        public int N { get; set; }

        public Piramide(int n)
        {
            if(n < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.N = n;
        }

        public void Desenha(Piramide p)
        {
            for(int i = 1; i <= p.N; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
} 
