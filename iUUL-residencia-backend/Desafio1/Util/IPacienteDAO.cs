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
        void Adicionar(Paciente p);

        void Remover(Paciente p);

        IList<Paciente> RetornaPacientes();

        List<Paciente> ListarPorNome();

        List<Paciente> ListarPorCpf();  

    }
}
