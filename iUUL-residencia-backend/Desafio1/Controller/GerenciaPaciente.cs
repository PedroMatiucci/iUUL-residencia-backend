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
    internal class GerenciaPaciente
    {

        PacienteDAO pacienteDAO = new PacienteDAO();
        public List<Paciente> Pacientes { get; private set; }

        public GerenciaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        internal bool ExistePaciente(string? entrada)
        {
            if(entrada == null) return false;
            IEnumerable<Paciente> Pacientes = pacienteDAO.RetornaPacientes().Where(p => p.CPF == entrada); 
            return Pacientes.Count() != 0;
        }

        internal void AdicionaPaciente(Paciente p)
        {
            pacienteDAO.Adicionar(p);
            Pacientes.Add(p);
        }

        internal void RemovePaciente(string cpf)
        {
            var paciente = this.RetornaPaciente(cpf);

            if (paciente == null) throw new Exception();

            // Pacientes com consulta futura não podem ser removidos
            if (paciente.ExisteAgendamento())
                throw new Exception();
            pacienteDAO.Remover(paciente);
        }

        

        internal Paciente? RetornaPaciente(string cpf)
        {
            Paciente? paciente = pacienteDAO.RetornaPacientes().Where(p => p.CPF == cpf).FirstOrDefault();
            return paciente;
        }
    }
}
