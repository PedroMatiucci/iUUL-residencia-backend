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
            int lines = p.N;
            int lineCounter = 1;
            int spaceCounter = 1;
            int prints = 1;
            int counter = 1;

            while(lineCounter <= lines)
            {
                for(spaceCounter = lineCounter; spaceCounter < lines; spaceCounter++)
                {
                    Console.Write(" ");
                }
                if (lineCounter != 1)
                {
                    for (prints = 1; prints < lineCounter; prints++)
                    {
                        Console.Write(counter);
                        ++counter;
                    }
                    for(prints = 1; prints <= lineCounter; prints++)
                    {
                        Console.Write(counter);
                        --counter;
                    }
                }
                else
                {
                    Console.Write(counter);
                }
                
                ++lineCounter;
                counter = 1;
                Console.WriteLine();
            }
        }
    }
} 
