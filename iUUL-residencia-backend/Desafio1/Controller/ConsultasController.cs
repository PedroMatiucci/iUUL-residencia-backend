using Consultorio.DB;
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
        DAO DAO = new DAO();

        public void AdicionaConsulta(DateOnly data, string horaInicial, string horaFinal, string cpf)
        {
            DAO.AdicionarConsulta(data,horaInicial,horaFinal,cpf);
        }

        public void RemoveConsulta(ConsultaForm c)
        {
                var dataAgora = DateOnly.FromDateTime(DateTime.Now);
                var dataForm = DateOnly.FromDateTime(DateTime.Parse(c.DataConsulta));
                List<Consulta> consultas = DAO.RetornaConsultas();
                if (consultas != null)
                {
                    if (dataAgora.CompareTo(dataForm) < 0 || dataAgora.CompareTo(dataForm) == 0)
                    {
                        foreach (var consulta in consultas)
                        {
                            if (consulta.Paciente.CPF == c.CPF
                                && consulta.DataConsulta == dataForm
                                && consulta.HoraInicial == c.HoraInicial)
                            {
                                DAO.RemoverConsulta(consulta);
                                return;
                            }
                        }
                    }
                }

                throw new Exception();
        }

        public List<Consulta> RetornaConsultas()
        {
            return DAO.RetornaConsultas();
        }
    }
}
