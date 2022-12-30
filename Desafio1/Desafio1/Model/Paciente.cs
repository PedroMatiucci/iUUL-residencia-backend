using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Paciente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        private Consulta? consulta;
        public Consulta Consulta
        {
            get { return consulta; }
            set
            {
                if (consulta == null || value == null) // Para excluir a consulta, o value será null.
                {
                    // se for a marcação de uma consulta, verificar sobreposição
                    if(value != null)
                        if (Agenda.PossuiAgendamentoSobreposto(value))
                            throw new Exception();
                            
                    consulta = value;
                } 


                // Não pode existir agendamentos futuros
                else if (Agenda.PossuiAgendamentoFuturo(value))
                    throw new Exception();
                    

                // Não pode existir agendamentos sobrepostos
                else if (Agenda.PossuiAgendamentoSobreposto(value))
                    throw new Exception();
                    

                else
                    consulta = value;
            } //$END_SET
        }

        public Paciente(string nome, string cpf, DateTime data)
        {
            consulta = null;
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }
    }
}
