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
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        private Consulta? consulta;
        public Consulta Consulta
        {
            get { return consulta; }
            set
            { // Não pode existir agendamentos futuros

                if(consulta == null)
                    consulta = value;

                else if (DateOnly.FromDateTime(DateTime.Now).CompareTo(
                    value.DataConsulta) < 0)
                    throw new Exception();

                else 
                    consulta = value;
            }
        }

        public Paciente(string nome, long cpf, DateTime data)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }
    }
}
