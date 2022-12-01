using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    public class Errors
    {
        public bool IsClienteNomeValid = false;
        public bool IsClienteCPFValid = false;
        public bool IsClienteDataNascimentoValid = false;
        public bool IsClienteRendaMensalValid = false;
        public bool IsClienteEstadoCivilValid = false;
        public bool IsClienteQtdDependentesValid = false;

        public string? nome { get; set; }
        public string? cpf { get; set; }
        public string? dt_nascimento { get; set; }
        public string? renda_mensal { get; set; }
        public string? estado_civil { get; set; }
        public string? dependentes { get; set; }

        private Errors dados { get; set; }
        //private Dictionary<string, string>? erros;

        public Errors() { }

        public void StoreClienteErrors()
        {
            string filename = "myerros.json";

            Errors err = new()
            {
                dados = this
            };

            string jsonstr = JsonSerializer.Serialize(err);

            File.WriteAllText(filename,jsonstr);


            return;
        }

    }
}
