using Consultorio.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Agenda
    {
        public List<Consulta> Consultas { get; set; }

        public Agenda()
        {
            Consultas = new List<Consulta>();
        }

        internal bool RemoveConsulta(ConsultaForm consultaForm)
        {
            foreach (Consulta consulta in this.Consultas)
            {
                if (consulta.CPF.Equals(consultaForm.CPF))
                {
                    // Se a data de AGORA for ANTERIOR
                    // à data da consulta que se deseja desmarcar,
                    // ou seja, se a data estiver no futuro
                    if(DateOnly.FromDateTime(DateTime.Now)
                        .CompareTo(DateOnly.FromDateTime(
                            DateTime.Parse(consultaForm.DataConsulta))) < 0)
                    {
                        // e se essa data da consulta for igual
                        // à data marcada
                        if (consulta.DataConsulta
                            .CompareTo(DateOnly.FromDateTime(
                                DateTime.Parse(consultaForm.DataConsulta))) == 0)
                        {
                            // removemos.
                            Consultas.Remove(consulta);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
