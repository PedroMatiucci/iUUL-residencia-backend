using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Consulta
    {
        public long CPF { get; private set; }
        public DateOnly DataConsulta { get; private set; }
        public string HoraInicial { get; private set; }
        public string HoraFinal { get; private set; }

        public Consulta(long cpf, DateOnly data, string h1, string h2)
        {
            this.CPF = cpf;
            this.DataConsulta = data;
            this.HoraInicial = h1;
            this.HoraFinal = h2;
        }
    }
}
