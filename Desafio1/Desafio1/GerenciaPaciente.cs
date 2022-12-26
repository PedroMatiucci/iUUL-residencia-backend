using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class GerenciaPaciente
    {
        public List<Paciente> Pacientes { get; private set;}

        public GerenciaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        internal bool ExistePaciente(string entrada)
        {
            long cpf = long.Parse(entrada);
            foreach(Paciente paciente in this.Pacientes)
            {
                if(paciente.CPF == cpf)
                    return true;
            }
            return false;
        }

        internal bool ExisteAgendamento(string cpf)
        {
            foreach (Paciente paciente in this.Pacientes)
            {
                if (paciente.Equals(cpf))
                    if (paciente.Consulta != null &&
                        paciente.Consulta.DataConsulta >
                        DateOnly.FromDateTime(DateTime.Now))
                        return true;
            }

            return false;
        }
    }
}
