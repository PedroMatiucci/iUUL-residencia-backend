using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.View
{
    internal static class ViewMenu
    {
        public static int MenuPrincipal()
        {
            string entrada;
            int escolha;
            do
            {
                Console.WriteLine("Menu Principal" +
                "\n1-Cadastro de Pacientes" +
                "\n2-Agenda" +
                "\n3-Fim");

                entrada = Console.ReadLine();
                escolha = int.Parse(entrada);
            }
            while (!ValidaMenusView.ValidaEscolhaAte3(escolha));

            return escolha;
        }

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
    }
}
