using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Validators;

namespace Consultorio.View
{
    internal static class ViewMenu
    {
        public static int MenuPrincipal()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nMenu Principal" +
                "\n1-Cadastro de Pacientes" +
                "\n2-Agenda" +
                "\n3-Fim");

                escolha = Console.ReadLine();
            }
            while (!ValidaMenusView.ValidaEscolha(escolha,3));

            return int.Parse(escolha);
        }

        public static int MenuCadastroPaciente()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nMenu do Cadastro de Pacientes" +
                    "\n1-Cadastrar novo paciente" +
                    "\n2-Excluir paciente" +
                    "\n3-Listar pacientes (ordenado por CPF)" +
                    "\n4-Listar pacientes (ordenado por nome)" +
                    "\n5-Voltar p/ menu principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaMenusView.ValidaEscolha(escolha, 5));

            return int.Parse(escolha);
        }

        public static int MenuAgenda()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nAgenda" +
                    "\n1-Agendar consulta" +
                    "\n2-Cancelar agendamento" +
                    "\n3-Listar agenda" +
                    "\n4-Voltar p/ Menu Principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaMenusView.ValidaEscolha(escolha, 4));

            return int.Parse(escolha);
        }

        public static int MenuListaAgenda()
        {
            string? escolha;
            do
            {
                Console.WriteLine("\nListar agenda" +
                "\n1-Listar agenda completa" +
                "\n2-Listar agenda por período" +
                "\n3-Voltar p/ Menu Principal");

                escolha = Console.ReadLine();
            }
            while (!ValidaMenusView.ValidaEscolha(escolha, 3));

            return int.Parse(escolha);
        }
    }
}
