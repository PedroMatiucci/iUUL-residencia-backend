using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Cliente
    {
        public string Nome { get; private set; }
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float RendaMensal { get; private set; }
        public char EstadoCivil { get; private set; }
        public int QtdDependentes { get; private set; }

        public Cliente(string Nome, long CPF, DateTime DataNascimento, float RendaMensal, char EstadoCivil, int QtdDependentes)
        {
            this.Nome = Nome;
            this.CPF = CPF;
            this.DataNascimento = DataNascimento;
            this.RendaMensal = RendaMensal;
            this.EstadoCivil = EstadoCivil;
            this.QtdDependentes = QtdDependentes;
        }
    }
}
