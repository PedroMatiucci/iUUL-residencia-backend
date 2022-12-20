using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class Consulta
    {
        public long CPF { get; set; }
        public DateOnly DataConsulta { get; set; }
        public int HoraInicial { get; set; }
        public int HoraFinal { get; set; }
        public List<Consulta> Agenda { get; set; }

        public Consulta()
        {
            Agenda = new List<Consulta>();
        }

        public void AgendarConsulta()
        {
            Consulta c = ViewCadastro.InsereDadosConsulta();
            c.Agenda.Add(c);
        }
    }
}
