using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Util
{
    internal interface IConsultaDAO
    {
        void Adicionar(Consulta c);

        void Remover(Consulta c);

        IList<Consulta> RetornaConsultas();

        IList<Paciente> RetornaConsultasPeriodo();

    }
}
