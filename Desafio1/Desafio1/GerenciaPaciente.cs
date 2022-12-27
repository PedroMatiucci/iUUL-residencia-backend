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

        internal bool ExistePaciente(string? entrada)
        {
            if(entrada == null) return false;

            foreach(Paciente paciente in this.Pacientes)
            {
                if(paciente.CPF.ToString() == entrada)
                    return true;
            }

            return false;
        }

        internal bool ExisteAgendamento(string cpf)
        {
            foreach (Paciente paciente in this.Pacientes)
            {
                if (paciente.Equals(cpf))
                {
                    return (paciente.Consulta != null) && 
                        (DateOnly.FromDateTime(DateTime.Now).CompareTo(paciente.Consulta.DataConsulta) < 0);
                }
            }

            return false;
        }
    }
}