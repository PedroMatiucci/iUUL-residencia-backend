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
    }
}
