﻿using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Util
{
    internal interface IConsultaDAO
    {
        void AdicionarConsulta(DateOnly data, string horaInicial, string horaFinal, string cpf);

        void RemoverConsulta(Consulta c);

        List<Consulta> RetornaConsultas();

    }
}
