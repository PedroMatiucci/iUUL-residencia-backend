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
        public static PacienteForm CadastroCliente()
        {
            PacienteForm cf = new();
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
                valido = ValidaPacienteForm.IsCPF(entrada);
            } while (!valido);

            do
            {
                if (valido == false)
                {
                    Console.WriteLine("\n[ERRO] Cliente já cadastrado.\n");
                    goto CPF;
                }
                    
                valido = GerenciaPaciente.ProcuraPaciente(entrada);
            } while (!valido);

            cf.CPF = entrada;

            do
            {
                if (valido == false)
                    Console.WriteLine("\n[ERRO] Nome deve ter pelo menos 05 caracteres.\n");
                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                valido = ValidaPacienteForm.IsNome(entrada);
            } while (!valido);

            cf.Nome = entrada;

            do
            {
                if(valido == false)
                    Console.WriteLine("\n[ERRO] Data inválida / Cliente precisa ter 13 anos.\n");
                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                valido = ValidaPacienteForm.IsDataNascimento(entrada);
            } while (!valido);

            cf.DataNascimento = entrada;

            return cf;
        }

        public static Consulta InsereDadosConsulta()
        {
            Consulta c = new();
            string? entrada;

            long cpf = ViewCadastro.InsereCPF();
            c.CPF = cpf;

            DateOnly data = ViewCadastro.InsereDataConsulta();
            c.DataConsulta = data;

            int[] horasInicialFinal = new int[2];
            horasInicialFinal = ViewCadastro.InsereHora();
            c.HoraInicial = horasInicialFinal[0];
            c.HoraFinal = horasInicialFinal[1];

            return c;
        }

        private static int[] InsereHora()
        {
            HORA:
            Console.WriteLine("Hora inicial: ");
            string? entrada = Console.ReadLine();

            int[] horasInicialFinal = new int[2];
            try
            {
                horasInicialFinal[0] = int.Parse(entrada);
            }
            catch
            {
                ViewMensagens.ExibeMensagemErroHora();
                goto HORA;
            }

            HORA_FINAL:
            Console.WriteLine("Hora final: ");
            entrada = Console.ReadLine();

            try
            {
                horasInicialFinal[1] = int.Parse(entrada);
            }
            catch
            {
                ViewMensagens.ExibeMensagemErroHora();
                goto HORA_FINAL;
            }

            if (ValidaPacienteForm.PossuiHoraConflitante(horasInicialFinal))
            {
                ViewMensagens.ExibeMensagemAgendamento(false);
                goto HORA;
            }
            else ViewMensagens.ExibeMensagemAgendamento(true);

            return horasInicialFinal;
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

                valido = ValidaPacienteForm.IsCPF(entrada);

            }while(!valido);
            return long.Parse(entrada);
        }

        private static DateOnly InsereDataConsulta()
        {
        DATA:
            Console.WriteLine("Data da consulta: ");
            string? entrada = Console.ReadLine();
            DateOnly data;
            try
            {
                data = DateOnly.Parse(entrada);
            }
            catch
            {
                Console.WriteLine("\nErro: Data inválida.");
            }
            return data;
        }
    }
}
