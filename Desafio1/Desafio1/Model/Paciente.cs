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
                if(consulta == null)
                    consulta = value;

                // Não pode existir agendamentos futuros
                else if (DateOnly.FromDateTime(DateTime.Now).CompareTo(
                    value.DataConsulta) < 0)
                    throw new Exception();
                // Não pode haver consultas sobrepostas
                else if (Agenda.HorarioIndisponivel(value)) 
                    throw new Exception();

                else
                    consulta = value;
            }
        }

        public Paciente(string nome, string cpf, DateTime data)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }
    }
}
