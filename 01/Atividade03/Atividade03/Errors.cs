using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    internal class Errors
    {
        protected internal bool IsClienteNomeValid = false;
        protected internal bool IsClienteCPFValid = false;
        protected internal bool IsClienteDataNascimentoValid = false;
        protected internal bool IsClienteRendaMensalValid = false;
        protected internal bool IsClienteEstadoCivilValid = false;
        protected internal bool IsClienteQtdDependentesValid = false;

        protected internal string? nome { get; set; }
        protected internal string? cpf { get; set; }
        protected internal string? dt_nascimento { get; set; }
        protected internal string? renda_mensal { get; set; }
        protected internal string? estado_civil { get; set; }
        protected internal string? dependentes { get; set; }

        private IList<Errors>? dados { get; set; }

        public Errors() { }

        protected internal void StoreClienteErrors()
        {
            string filename = "myerros.json";

            var clienteerr = new Errors
            {
                dados = new List<Errors> { this }
            };
            string jsonstr = JsonSerializer.Serialize(clienteerr);

            File.WriteAllText(filename,jsonstr);

            return;
        }

    }
}
