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
        public static List<Consulta>? Consultas { get; private set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }

        internal bool RemoveConsulta(ConsultaForm consultaForm)
        {
            foreach(var consulta in Consultas)
            {
                if
                (consulta.CPF == consultaForm.CPF 
                    && consulta.DataConsulta == DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta))
                    && consulta.HoraInicial == consultaForm.HoraInicial
                )
                {
                    Consultas.Remove(consulta);
                    return true;
                }
            }

            return false;
        }

        internal static bool HorarioIndisponivel(Consulta entrada)
        {
            if (Consultas != null)
            {
                foreach (var c in Consultas)
                {
                    if(c.DataConsulta == entrada.DataConsulta)
                    {
                        // 1 - Se a hora inicial de qualquer consulta
                        // for igual a hora inicial da entrada.
                        if (c.HoraInicial == entrada.HoraInicial)
                            return true;
                        // 2 - Se a hora inicial e final de qualquer consulta
                        // for menor e maior, respectivamente, que a hora inicial da entrada. (entre)
                        else if (c.HoraInicial.CompareTo(entrada.HoraInicial) < 0 && c.HoraFinal.CompareTo(entrada.HoraInicial) > 0)
                            return true;
                        // 3 - Se a hora inicial e final de qualquer consulta
                        // for maior e menor, respectivamente, que a hora final da entrada. (entre)
                        else if (c.HoraInicial.CompareTo(entrada.HoraFinal) > 0 && c.HoraFinal.CompareTo(entrada.HoraFinal) < 0)
                            return true;
                    }
                }
            }
            
            return false;
        }
    }
}
