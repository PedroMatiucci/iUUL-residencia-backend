using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Util
{
    internal interface IPacienteDAO
    {
        void AdicionarPaciente(Paciente p);

        void RemoverPaciente(Paciente p);

        List<Paciente> RetornaPacientes();

        List<Paciente> ListarPorNome();

        List<Paciente> ListarPorCpf();  

    }
}
