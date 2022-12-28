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
        public int HoraInicial { get; private set; }
        public int HoraFinal { get; private set; }

        public Consulta(long cpf, DateOnly data, int h1, int h2)
        {
            CPF = cpf;
            DataConsulta = data;
            HoraInicial = h1;
            HoraFinal = h2;
        }
    }
}
