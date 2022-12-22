using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal static class ViewMensagens
    {
        /************
         * PACIENTE *
         ***********/
        public static void ExibeMensagemCadastroPaciente()
        {
            Console.WriteLine("\nPaciente cadastrado com sucesso!\n");
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

        /**********
         * AGENDA *
         *********/
        internal static void ExibeMensagemAgendamento(bool v)
        {
            if(!v) Console.WriteLine("\nErro: Já existe uma consulta agendada neste horário.\n");
            else Console.WriteLine("\nAgendamento realizado com sucesso\n");
        }

        /*************
         * DATA/HORA *
         ************/
        internal static void ExibeMensagemErroHora()
        {
            Console.WriteLine("\nErro: Hora inválida.\n");
        }
        internal static void ExibeMensagemErroData()
        {
            Console.WriteLine("\nErro: Data inválida / Paciente precisa ter pelo menos 13 anos.\n");
        }

        /*******
         * CPF *
         ******/
        internal static void ExibeMensagemErroCPF()
        {
            Console.WriteLine("\nErro: CPF inválido.\n");
        }
        internal static void ExibeMensagemErroCPFCadastrado()
        {
            Console.WriteLine("\nErro: CPF já cadastrado.\n");
        }

        /********
         * Nome *
         *******/
        internal static void ExibeMensagemErroNome()
        {
            Console.WriteLine("\nErro: Nome deve ter pelo menos 05 (cinco) caracteres.\n");
        }
    }
}
