using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class GerenciaPaciente
    {
        public List<Paciente> Pacientes { get; set;}

        public GerenciaPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        public bool ExistePaciente(string entrada)
        {
            long cpf = long.Parse(entrada);
            foreach(Paciente paciente in this.Pacientes)
            {
                if(paciente.CPF == cpf)
                    return true;
            }
            return false;
        }
    }
}
