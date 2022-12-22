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
        public Paciente Paciente { get; set; }
        public long CPF { get; set; }
        public DateOnly DataConsulta { get; set; }
        public int HoraInicial { get; set; }
        public int HoraFinal { get; set; }
        
        public Consulta(Paciente paciente,long cpf,DateOnly data, int h1, int h2)
        {
            this.Paciente = paciente;
            this.CPF = cpf;
            this.DataConsulta = data;
            this.HoraInicial = h1;
            this.HoraFinal = h2;
        }

        public bool AgendarConsulta()
        {
            /*
            // verificar se existe agendamento
            if (ValidaAgendaForm.PossuiHoraConflitante(this.Agenda,))
            {
                // se sim
                return false;
            }
            
            
            // se não
            this.Agenda.Add(this);
            return true;
            */
            return true;
        }

        private bool VerificaAgendamento()
        {
            return true;
        }
    }
}
