using Atividade02.Q1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Cliente
    {
        protected internal string Nome { get; set; }
        protected internal long CPF { get; set; }
        protected internal DateTime DataNascimento { get; set; }
        protected internal float RendaMensal { get; set; }
        protected internal char EstadoCivil { get; set; }
        protected internal int QtdDependentes { get; set; }

        public Cliente(ClienteForm cf)
        {
            this.Nome = cf.Nome;
            this.CPF = long.Parse(cf.CPF);
            this.DataNascimento = DateTime.Parse(cf.DataNascimento);
            this.RendaMensal = float.Parse(cf.RendaMensal);
            this.EstadoCivil = char.Parse(cf.EstadoCivil);
            this.QtdDependentes = int.Parse(cf.QtdDependentes);
        }
    }
}
