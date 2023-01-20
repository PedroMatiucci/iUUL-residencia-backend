using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioDB
{
    internal class ConsultaForm
    {
        public string? CPF { get; set; }
        public string? DataConsulta { get; set; }
        public string? HoraInicial { get; set; }
        public string? HoraFinal { get; set; }

        public ConsultaForm() { }

        internal void RemoveConsulta(Agenda a)
        {
            var dataAgora = DateOnly.FromDateTime(DateTime.Now);
            var dataForm = DateOnly.FromDateTime(DateTime.Parse(this.DataConsulta));

            if (a.Consultas != null)
            {
                if (dataAgora.CompareTo(dataForm) < 0 || dataAgora.CompareTo(dataForm) == 0)
                {
                    foreach (var c in a.Consultas)
                    {
                        if (c.CPF == this.CPF
                            && c.DataConsulta == dataForm
                            && c.HoraInicial == this.HoraInicial)
                        {
                            a.Consultas.Remove(c);
                            return;
                        }
                    }
                }
            }

            throw new Exception();
        }
    }
}
