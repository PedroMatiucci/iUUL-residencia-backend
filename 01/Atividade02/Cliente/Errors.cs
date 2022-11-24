using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q1
{
    internal class Errors
    {
        public List<bool> HasErrors(ValidaClienteForm cf)
        {


            //Nome
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: nome");
            Console.WriteLine($"Dado: {nome}");
            Console.WriteLine("Erro: Nome possui menos de 5 caracteres.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            //CPF
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: CPF deve conter 11 dígitos.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: Números do CPF não podem ser todos iguais.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: CPF Inválido: Primeiro dígito verificador não confere.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: CPF Inválido: Primeiro dígito verificador não confere.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: CPF Inválido: Segundo dígito verificador não confere.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: cpf");
            Console.WriteLine($"Dado: {cpf}");
            Console.WriteLine("Erro: CPF Inválido: Segundo dígito verificador não confere.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            //Valida DataNascimento
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: dataNascimento");
            Console.WriteLine($"Dado: {dt}");
            Console.WriteLine("Erro: Formatação fora do padrão dd/mm/yyyy.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: dataNascimento");
            Console.WriteLine($"Dado: {anoNascimento}");
            Console.WriteLine("Erro: Idade menor do que 18 anos.");
            Console.WriteLine(">> ");
            Console.ReadLine();


            //Valida RendaMensal
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: rendaMensal");
            Console.WriteLine($"Dado: {renda}");
            Console.WriteLine("Erro: Renda menor do que zero.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            //Valida EstadoCivil
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: estadoCivil");
            Console.WriteLine($"Dado: {estadoCivil}");
            Console.WriteLine("Erro: Estado civil desconhecido.");
            Console.WriteLine(">> ");
            Console.ReadLine();

            //Valida QtdDependentes
            Console.WriteLine("\n---------ERRO----------");
            Console.WriteLine("Nome do campo: qtdDependentes");
            Console.WriteLine($"Dado: {qtd}");
            Console.WriteLine("Erro: Quantidade de dependentes menor que 0 ou maior que 10.");
            Console.WriteLine(">> ");
            Console.ReadLine();


        }
    }
}
