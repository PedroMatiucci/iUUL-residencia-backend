using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.Model.Daos;
using Consultorio.View;

namespace Consultorio.Controller
{
    internal class PacienteController
    {

        DAO DAO = new DAO();


        internal bool ExistePaciente(string? entrada)
        {
            if(entrada == null) return false;
            IEnumerable<Paciente> Pacientes = DAO.RetornaPacientes().Where(p => p.CPF == entrada); 
            return Pacientes.Count() != 0;
        }

        internal void AdicionaPaciente(Paciente p)
        {
            DAO.AdicionarPaciente(p);
        }

        internal void RemovePaciente(string cpf)
        {
            var paciente = RetornaPaciente(cpf);

            if (paciente == null) throw new Exception();

            // Pacientes com consulta futura não podem ser removidos
            if (paciente.ExisteAgendamento())
                throw new Exception();
            DAO.RemoverPaciente(paciente);
        }

        
        internal Paciente? RetornaPaciente(string cpf)
        {
            Paciente? paciente = DAO.RetornaPacientes().Where(p => p.CPF == cpf).FirstOrDefault();
            return paciente;
        }

        internal List<Paciente> RetornaPacientesPorCPF()
        {
            return DAO.ListarPorCpf();
        }

        internal List<Paciente> RetornaPacientesPorNome()
        {
            return DAO.ListarPorNome();
        }
    }
}
