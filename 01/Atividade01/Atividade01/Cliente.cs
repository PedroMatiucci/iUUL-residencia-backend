using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Cliente
    {
        public string nome;
        public long cpf;
        public DateTime data_nascimento;
        public float renda_mensal;
        public char estado_civil;
        public int qtd_dependentes;

        public Cliente(string nome, string cpf, string data_nascimento, string renda_mensal, string estado_civil, string qtd_dependentes)
        {
            String nome_validado = ValidaNome(nome);
            this.nome = nome_validado;

            long cpf_validado = ValidaCPF(cpf);
            this.cpf = cpf_validado;

            DateTime data_nascimento_validado = ValidaNascimento(data_nascimento);
            this.data_nascimento = data_nascimento_validado;

            float renda_mensal_validado = ValidaRendaMensal(renda_mensal);
            this.renda_mensal = renda_mensal_validado;

            char estado_civil_validado = ValidaEstadoCivil(estado_civil);
            this.estado_civil = estado_civil_validado;

            int qtd_dependentes_validado = ValidaQtdDependentes(qtd_dependentes);
            this.qtd_dependentes = qtd_dependentes_validado;
        }

        private String ValidaNome(string nome)
        {
            while (nome.Length < 5)
            {
                Console.WriteLine("Favor, inserir nome de pelo menos 5 caracteres: ");
                nome = Console.ReadLine();
            }
            return nome;
        }
        private long ValidaCPF(string cpf)
        {
            while (cpf.Length != 11)
            {
                Console.WriteLine("Favor, inserir CPF de 11 dígitos: ");
                cpf = Console.ReadLine();
            }
            return long.Parse(cpf);
        }

        private DateTime ValidaNascimento(String dt)
        {
            String format = "dd/MM/yyyy";
            DateTime date = DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture);

            DateTime now = DateTime.Now;

            int year = date.Year;
            int nowYear = now.Year;

            while ((nowYear - year) < 18)
            {
                Console.WriteLine("A data deve dar pelo menos 18 anos: ");
                dt = Console.ReadLine();

                date = DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture);
                year = date.Year;
            }

            return date;
        }

        private float ValidaRendaMensal(String renda)
        {
            float myFloat = float.Parse(renda);
            while (true)
            {
                if (!renda.Contains(','))
                {
                    Console.WriteLine("O valor deverá ter vírgula na casa decimal: ");
                    renda = Console.ReadLine();
                }
                else
                {
                    return float.Parse(renda.Remove(renda.IndexOf(',')+3));
                }
            }
        }

        enum EC
        {
            C,
            S,
            V,
            D
        }

        private char ValidaEstadoCivil(String estadoCivil)
        {

            while (true)
            {
                foreach (var ec in Enum.GetNames(typeof(EC)))
                {
                    if (estadoCivil.ToUpper() == ec.ToString())
                    {
                        return char.Parse(estadoCivil.ToUpper());
                    }
                }
                Console.WriteLine("Favor inserir um estado civil válido (C c / S s / V v / D d): ");
                estadoCivil = Console.ReadLine();
            }
        }

        private int ValidaQtdDependentes(String qtd)
        {
            int dependentes = int.Parse(qtd);
            while(dependentes < 0 || dependentes > 10)
            {
                Console.WriteLine("Quantidade válida entre 0 e 10: ");
                qtd = Console.ReadLine();
            }
            return dependentes = int.Parse(qtd);
        }

        public void ImprimeCliente(Cliente c)
        {
            Console.WriteLine();
            Console.WriteLine("==========Imprimindo cliente===========");
            Console.WriteLine("Nome: "+c.nome);
            Console.WriteLine("CPF: " + c.cpf);
            Console.WriteLine("Nascimento: "+c.data_nascimento);
            Console.WriteLine("Renda mensal: " + c.renda_mensal);
            Console.WriteLine("Estado civil: " + c.estado_civil);
            Console.WriteLine("Quantidade de dependentes: " + c.qtd_dependentes);
        }
    }
}
