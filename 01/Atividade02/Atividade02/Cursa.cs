using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Atividade02
{
    abstract class Cursa
    {
        public float P1;
        public float P2;
        public float PF
        {
            get
            {
                return this.PF;
            }
            set
            {
                this.PF = (P1 + P2) / 2; ;
            }
        }
    }
}
