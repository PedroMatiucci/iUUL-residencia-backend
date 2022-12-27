using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    internal class Paciente
    {
        public string Nome { get; private set; }
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Consulta? Consulta { get; set; }

        public Paciente(string nome, long cpf, DateTime data)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }
    }
}
