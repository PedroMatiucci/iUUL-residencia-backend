using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Agenda
    {
        public List<Consulta> Consultas { get; set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }
    }
}
