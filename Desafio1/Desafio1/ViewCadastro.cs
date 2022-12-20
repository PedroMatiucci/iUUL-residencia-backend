using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal static class ViewCadastro
    {
        public static ClienteForm CadastroCliente()
        {
            ClienteForm cf = new();
            string entrada;
            bool valido = true;

            CPF:
            do
            {
                // Indicar se houve algum erro na entrada.
                if(valido == false)
                    Console.WriteLine("\n[ERRO] CPF inválido.");

                // Ler entrada do usuário.
                Console.Write("\nCPF: ");
                entrada = Console.ReadLine();

                // Validar.
                valido = ValidaClienteForm.IsCPF(entrada);
            } while (!valido);

            do
            {
                if (valido == false)
                {
                    Console.WriteLine("\n[ERRO] Cliente já cadastrado.\n");
                    goto CPF;
                }
                    
                valido = ValidaClienteForm.ProcuraCliente(entrada);
            } while (!valido);

            cf.CPF = entrada;

            do
            {
                if (valido == false)
                    Console.WriteLine("\n[ERRO] Nome deve ter pelo menos 05 caracteres.\n");
                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                valido = ValidaClienteForm.IsNome(entrada);
            } while (!valido);

            cf.Nome = entrada;

            do
            {
                if(valido == false)
                    Console.WriteLine("\n[ERRO] Data inválida / Cliente precisa ter 13 anos.\n");
                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                valido = ValidaClienteForm.IsDataNascimento(entrada);
            } while (!valido);

            cf.DataNascimento = entrada;

            return cf;
        }

        public static long InsereCPF()
        {
            string? entrada;
            bool valido = true;
            do
            {
                if (valido == false)
                    Console.WriteLine("\n[ERRO] CPF inválido.");
                Console.Write("\nCPF: ");
                entrada = Console.ReadLine();

                valido = ValidaClienteForm.IsCPF(entrada);

            }while(!valido);
            return long.Parse(entrada);
        }

        public static Agenda InsereDadosConsulta()
        {
            Agenda a = new();

            long cpf = ViewCadastro.InsereCPF();

            a.cpf = cpf;

            //continuar por aqui...
        }
    }
}
