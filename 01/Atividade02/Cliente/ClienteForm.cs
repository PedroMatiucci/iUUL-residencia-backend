using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q1
{
    internal class ClienteForm
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string RendaMensal { get; set; }
        public string EstadoCivil { get; set; }
        public string QtdDependentes { get; set; }

        public ClienteForm(string Nome, string CPF, string DataNascimento, string RendaMensal, string EstadoCivil, string QtdDependentes)
        {
            this.Nome = Nome;
            this.CPF = CPF;
            this.DataNascimento = DataNascimento;
            this.RendaMensal = RendaMensal;
            this.EstadoCivil = EstadoCivil;
            this.QtdDependentes = QtdDependentes;
        }

        public ClienteForm ReadData()
        {
            Console.WriteLine("Insira um nome: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Insira um cpf: ");
            string CPF = Console.ReadLine();
            Console.WriteLine("Insira uma data de nascimento (dd/mm/yyyy): ");
            string DataNascimento = Console.ReadLine();
            Console.WriteLine("Insira uma renda mensal: ");
            string RendaMensal = Console.ReadLine();
            Console.WriteLine("Insira um estado civil (C c / S s / V v / D d): ");
            string EstadoCivil = Console.ReadLine();
            Console.WriteLine("Insira uma quantidade de dependentes: ");
            string QtdDependentes = Console.ReadLine();

            ClienteForm cf = new(Nome, CPF, DataNascimento, RendaMensal, EstadoCivil, QtdDependentes);

            return cf;
        }

        public void PrintValidCliente(Cliente c)
        {
            Console.WriteLine();
            Console.WriteLine("---------SUCESSO----------");
            Console.WriteLine("==========Imprimindo cliente===========");
            Console.WriteLine("Nome: " + c.Nome);
            Console.WriteLine("CPF: " + c.CPF);
            Console.WriteLine("Nascimento: " + c.DataNascimento);
            Console.WriteLine("Renda mensal: " + c.RendaMensal);
            Console.WriteLine("Estado civil: " + c.EstadoCivil);
            Console.WriteLine("Quantidade de dependentes: " + c.QtdDependentes);
        }
    }
}
