using Consultorio.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Agenda : List<Consulta>
    {
        public List<Consulta> Consultas { get; set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }

        internal bool RemoveConsulta(ConsultaForm consultaForm)
        {
            foreach(var consulta in Consultas)
            {
                if
                (consulta.CPF == long.Parse(consultaForm.CPF) 
                    && consulta.DataConsulta == DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta))
                    && consulta.HoraInicial == int.Parse(consultaForm.HoraInicial)
                )
                {
                    Consultas.Remove(consulta);
                    return true;
                }
            }

            return false;
        }
    }
}
