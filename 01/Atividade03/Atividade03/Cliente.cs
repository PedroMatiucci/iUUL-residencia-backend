using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade03.Q1
{
    internal class Cliente
    {
        protected internal string Nome { get; set; }
        protected internal long CPF { get; set; }
        protected internal DateTime DataNascimento { get; set; }
        protected internal float RendaMensal { get; set; }
        protected internal char EstadoCivil { get; set; }
        protected internal int QtdDependentes { get; set; }

        public Cliente() { }
        public Cliente(ClienteForm cf)
        {
            this.Nome = cf.nome;
            this.CPF = long.Parse(cf.cpf);
            this.DataNascimento = DateTime.Parse(cf.dt_nascimento);
            this.RendaMensal = float.Parse(cf.renda_mensal);
            this.EstadoCivil = char.Parse(cf.estado_civil);
            this.QtdDependentes = int.Parse(cf.dependentes);
        }
    }
}
