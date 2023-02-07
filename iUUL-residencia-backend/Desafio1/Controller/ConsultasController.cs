﻿using Consultorio.DB;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.Model.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Controller
{
    internal class ConsultasController
    {
        PacienteDAO DAO = new PacienteDAO();

        public void AdicionaConsulta(DateOnly data, string horaInicial, string horaFinal, string cpf)
        {
            DAO.AdicionarConsulta(data,horaInicial,horaFinal,cpf);
        }

        public void RemoveConsulta(Consulta c)
        {

        }
    }
}
