using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.View;

namespace Consultorio.Controller
{
    internal class GerenciaPaciente
    {
        public List<Paciente> Pacientes { get; private set; }

        public GerenciaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        internal bool ExistePaciente(string? entrada)
        {
            if(entrada == null) return false;

            foreach(Paciente paciente in this.Pacientes)
            {
                if(paciente.CPF == entrada)
                    return true;
            }

            return false;
        }

        internal bool RemovePaciente(string cpf)
        {
            var paciente = this.RetornaPaciente(cpf);

            if (paciente == null) return false;

            // Pacientes com consulta futura não podem ser removidos
            if (this.ExisteAgendamento(paciente))
                return false;

            this.Pacientes.Remove(paciente);

            return true;
        }

        internal bool ExisteAgendamento(Paciente paciente)
        {
            return (paciente.Consulta != null) &&
                        (DateOnly.FromDateTime(DateTime.Now).CompareTo(
                            paciente.Consulta.DataConsulta) < 0);
        }

        internal Paciente? RetornaPaciente(string cpf)
        {
            foreach (Paciente paciente in this.Pacientes) // Buscar o CPF.
            {
                //Verifica se existe um Paciente com este CPF
                if (paciente.CPF == cpf)
                {
                    return paciente;
                }
            }
            return null;
        }
    }
}
