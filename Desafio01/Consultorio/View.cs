using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    public class View
    {
        public static int MenuPrincipal()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\n\nMenu Principal" +
                "\n1-Cadastro de Pacientes" +
                "\n2-Agenda" +
                "\n3-Fim");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while(!ValidaMenusView.ValidaEscolhaAte3(escolha));

            return escolha;
        }

        public static int MenuCadastroPaciente()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\n\nMenu do Cadastro de Pacientes" +
                    "\n1-Cadastrar novo paciente" +
                    "\n2-Excluir paciente" +
                    "\n3-Listar pacientes (ordenado por CPF)" +
                    "\n4-Listar pacientes (ordenado por nome)" +
                    "\n5-Voltar p/ menu principal\n");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while (!ValidaMenusView.ValidaEscolhaAte5(escolha));

            return escolha;
        }

        public static int MenuAgenda()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("\n\nAgenda" +
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

            do
            {
                if(valido == false)
                    Console.WriteLine("\n[ERRO] CPF inválido.\n");
                Console.WriteLine("CPF: ");
                entrada = Console.ReadLine();
                valido = ValidaClienteForm.IsCPF(entrada);
            } while (!valido);

            do
            {
                if (valido == false)
                    Console.WriteLine("\n[ERRO] Cliente já cadastrado.\n");
                Console.WriteLine("CPF: ");
                entrada = Console.ReadLine();
                valido = ValidaClienteForm.ProcuraCliente(entrada);
            } while (!valido);

            cf.CPF = entrada;

            do
            {
                if (valido == false)
                    Console.WriteLine("\n[ERRO] Nome deve ter pelo menos 05 caracteres.");
                Console.WriteLine("Nome: ");
                entrada = Console.ReadLine();
                valido = ValidaClienteForm.IsNome(entrada);
            } while (!valido);

            cf.Nome = entrada;

            do
            {
                if(valido == false)
                    Console.WriteLine("\n[ERRO] Paciente deve ter pelo menos 13 anos.");
                Console.WriteLine("Data de Nascimento: ");
                entrada = Console.ReadLine();
                valido = ValidaClienteForm.IsDataNascimento(entrada);
            } while (!valido);

            cf.DataNascimento = entrada;

            return cf;
        }

        public static void ExibeMensagemCadastroCliente(bool valido)
        {
            if (valido) Console.WriteLine("\nCliente cadastrado com sucesso!\n");
            else Console.WriteLine("\nErro de cadastro.\n");
        }
    }
}
