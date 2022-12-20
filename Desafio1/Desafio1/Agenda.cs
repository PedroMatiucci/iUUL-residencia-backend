using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class Agenda
    {
        public long cpf { get; set; }
        public DateOnly data { get; set; }
        public int horaInicial { get; set; }
        public int horaFinal { get; set; }
        public List<Agenda> agendaList { get; set; }

        public Agenda()
        {
            agendaList= new List<Agenda>();
        }

        public bool AgendarConsulta()
        {
            Agenda c = ViewCadastro.InsereDadosConsulta();
            c.agendaList.Add(c);

            //continuar por aqui...
        }
    }
}
