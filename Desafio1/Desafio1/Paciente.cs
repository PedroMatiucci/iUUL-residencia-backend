using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class Paciente
    {
        public string Nome { get; private set; }
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Paciente(string nome, long cpf, DateTime data)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.DataNascimento = data;
        }
    }
}
