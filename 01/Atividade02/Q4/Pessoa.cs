using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q4
{
    internal class Pessoa
    {
        private String nome;
        private CertidaoNascimento certidaoNascimento { get; }

        public Pessoa(String nome)
        {
            this.nome = nome;
        }
    }
}
