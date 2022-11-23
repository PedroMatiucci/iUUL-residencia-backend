using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Cliente : ValidaCliente
    {
        protected internal String nome { get; private set; }
        protected internal long cpf { get; private set; }
        protected internal DateTime dataNascimento { get; private set; }
        protected internal float rendaMensal { get; private set; }
        protected internal Char estadoCivil { get; private set; }
        protected internal int qtdDependentes { get; private set; }

        public Cliente(string nome, string cpf, string dataNascimento, string rendaMensal, string estadoCivil, string qtdDependentes)
        {
            String nome_validado = ValidaNome(nome);
            this.nome = nome_validado;

            long cpf_validado = ValidaCPF(cpf);
            this.cpf = cpf_validado;

            DateTime dataNascimento_validado = ValidaNascimento(dataNascimento);
            this.dataNascimento = dataNascimento_validado;

            float rendaMensal_validado = ValidaRendaMensal(rendaMensal);
            this.rendaMensal = rendaMensal_validado;

            char estadoCivil_validado = ValidaEstadoCivil(estadoCivil);
            this.estadoCivil = estadoCivil_validado;

            int qtdDependentes_validado = ValidaQtdDependentes(qtdDependentes);
            this.qtdDependentes = qtdDependentes_validado;
        }
    }
}
