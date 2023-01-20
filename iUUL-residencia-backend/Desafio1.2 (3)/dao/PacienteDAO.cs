using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB.dao
{
    public static class PacienteDAO
    {
        public static bool ExistePaciente(string? entrada, List<Paciente> pacientes)
        {
            if (entrada == null) return false;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.CPF == entrada)
                    return true;
            }

            return false;
        }

        public static void RemovePaciente(string cpf, List<Paciente> pacientes)
        {
            var paciente = RetornaPaciente(cpf,pacientes);

            if (paciente == null) throw new Exception();

            // Pacientes com consulta futura não podem ser removidos
            if (paciente.ExisteAgendamento())
                throw new Exception();

            pacientes.Remove(paciente);
        }



        public static Paciente? RetornaPaciente(string cpf, List<Paciente> pacientes)
        {
            foreach (Paciente paciente in pacientes) // Buscar o CPF.
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
