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
        public long CPF { get; set; }
        public DateOnly DataConsulta { get; set; }
        public int HoraInicial { get; set; }
        public int HoraFinal { get; set; }

        public Consulta(long cpf, DateOnly data, int h1, int h2)
        {
            CPF = cpf;
            DataConsulta = data;
            HoraInicial = h1;
            HoraFinal = h2;
        }
    }
}
