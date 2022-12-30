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
            if(Consultas != null)
            {
                foreach (var consulta in Consultas)
                {
                    // Obs: Não possui verificação de não deletar uma consulta já passada.

                    if(consulta.CPF == consultaForm.CPF
                        && consulta.DataConsulta == DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta))
                        && consulta.HoraInicial == consultaForm.HoraInicial)
                        {
                            Consultas.Remove(consulta);
                            return true;
                        }
                }
            }

            return false;
        }


        internal static bool PossuiAgendamentoFuturo(Consulta entrada)
        {
            foreach(var c in Consultas)
            {
                if(c.CPF == entrada.CPF)
                {
                    // 1 - Se a data de agora for exatamente igual à data
                    // que já estava marcada (consulta hoje)
                    if (DateOnly.FromDateTime(DateTime.Now)
                        .CompareTo(c.DataConsulta) == 0)
                        return true;    

                    // 2 - Se a data de agora for menor que a data que já estava,
                    // significa que ainda não passou e, portanto,
                    // possui agendamento futuro.
                    if (DateOnly.FromDateTime(DateTime.Now)
                        .CompareTo(c.DataConsulta) < 0)
                        return true;

                    // 3 - self-explanatory
                    if (c.DataConsulta == entrada.DataConsulta)
                        return true;
                }
            }
            return false;
        }

        internal static bool PossuiAgendamentoSobreposto(Consulta entrada)
        {
            foreach (var c in Consultas)
            {
                if (c.DataConsulta == entrada.DataConsulta)
                {
                    // 1 - Se a hora inicial de qualquer consulta
                    // for igual a hora inicial da entrada.
                    if (c.HoraInicial == entrada.HoraInicial)
                        return true;
                    // 2 - A hora inicial da entrada não pode estar entre as horas da consulta
                    else if (int.Parse(entrada.HoraInicial) > int.Parse(c.HoraInicial) && int.Parse(entrada.HoraInicial) < int.Parse(c.HoraFinal))
                        return true;
                    // 2 - A hora final da entrada não pode estar entre as horas da consulta
                    else if (int.Parse(entrada.HoraFinal) > int.Parse(c.HoraInicial) && int.Parse(entrada.HoraFinal) < int.Parse(c.HoraFinal))
                        return true;
                }
            } //$END_FOREACH

            return false;
        }
    }
}
