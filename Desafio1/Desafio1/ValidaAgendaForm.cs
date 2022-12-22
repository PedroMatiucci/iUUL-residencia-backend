using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal static class ValidaAgendaForm
    {
        internal static bool PossuiHoraConflitante(List<Consulta> agenda, int[] horasInicialFinal)
        {
            foreach (Consulta consulta in agenda)
            {
                if (consulta.HoraInicial == horasInicialFinal[0] || consulta.HoraFinal == horasInicialFinal[1])
                    return true;

            }
            return false;
        }

        internal static bool DataConsultaValida(string? entrada)
        {
            if(entrada == null) return false;
            try
            {
                DateOnly data = DateOnly.Parse(entrada);
            }
            catch
            {
                return false;
            }
            return true;
        }

        internal static bool HoraValida(string? entrada)
        {
            if (entrada == null) return false;
            try
            {
                int hora = int.Parse(entrada);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
