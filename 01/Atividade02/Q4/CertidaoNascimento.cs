using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q4
{
    internal class CertidaoNascimento
    {
        private DateOnly dataEmissao;
        private Pessoa pessoa { get; }

        public CertidaoNascimento(Pessoa pessoa,DateOnly emissao)
        {
            this.dataEmissao= emissao;
            this.pessoa = pessoa;
        }
    }
}
