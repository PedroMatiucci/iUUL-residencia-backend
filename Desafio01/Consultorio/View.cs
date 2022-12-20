using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    public class View
    {
        /*
         * MENU PRINCIPAL
         */
        public static int MenuPrincipal()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\nMenu Principal" +
                "\n1-Cadastro de Pacientes" +
                "\n2-Agenda" +
                "\n3-Fim");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while(!ValidaMenusView.ValidaEscolhaAte3(escolha));

            return escolha;
        }

        /*
         * MENU CADASTRO DE PACIENTE
         */
        public static int MenuCadastroPaciente()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\nMenu do Cadastro de Pacientes" +
                    "\n1-Cadastrar novo paciente" +
                    "\n2-Excluir paciente" +
                    "\n3-Listar pacientes (ordenado por CPF)" +
                    "\n4-Listar pacientes (ordenado por nome)" +
                    "\n5-Voltar p/ menu principal");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while (!ValidaMenusView.ValidaEscolhaAte5(escolha));

            return escolha;
        }

        /*
         * MENU AGENDA
         */
        public static int MenuAgenda()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\nAgenda" +
                    "\n1-Agendar consulta" +
                    "\n2-Cancelar agendamento" +
                    "\n3-Listar agenda" +
                    "\n4-Voltar p/ menu principal");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while (!ValidaMenusView.ValidaEscolhaAte4(escolha));

            return escolha;
        }

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

        public static void ExibeMensagemCadastroCliente()
        {
            Console.WriteLine("\nPaciente cadastrado com sucesso!\n");
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
        public static void ExibeMensagemRemocaoPaciente(bool v)
        {
            if (v) Console.WriteLine("\nPaciente excluído com sucesso!\n");
            else Console.WriteLine("\nErro: paciente não cadastrado.\n");
        }

        internal static void ExibeMensagemRemocaoPacienteMarcado()
        {
            Console.WriteLine("\nErro: paciente está agendado.\n");
        }
        internal static void ExibeListaPacientes(List<Cliente> listaClientes)
        {
            //Metodo para listar pacientes, recebe uma lista ja ordenada pelo controlador e da o print nela
            Console.WriteLine("------------------------------------------------------------\r\nCPF Nome Dt.Nasc. Idade\r\n------------------------------------------------------------");
            foreach (Cliente cliente in listaClientes)
            {
                int idade = DateTime.Now.Year - cliente.DataNascimento.Year;
                Console.WriteLine("{0} {1} {2} {3}", cliente.CPF, cliente.Nome, cliente.DataNascimento, idade);
            }
            Console.WriteLine("------------------------------------------------------------");
        }


    }
}
