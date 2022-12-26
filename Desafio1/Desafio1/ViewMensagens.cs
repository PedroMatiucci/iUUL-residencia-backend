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
        public static void ExibeMensagemCadastroPaciente(bool v)
        {
            if (v) Console.WriteLine("\nPaciente cadastrado com sucesso!\n");
            else Console.WriteLine("\nErro: paciente não cadastrado.\n");
        }
        public static void ExibeMensagemRemocaoPaciente(bool v)
        {
            if (v) Console.WriteLine("\nPaciente excluído com sucesso!\n");
            else Console.WriteLine("\nErro: paciente não cadastrado.\n");
        }
        internal static void ExibeMensagemRemocaoPacienteAgendado()
        {
            Console.WriteLine("\nErro: paciente está agendado.\n");
        }
        public static void ExibeMensagemErroIdadePaciente()
        {
            Console.WriteLine("\nErro: paciente precisa ter pelo menos 13 anos.\n");
        }

        /**********
         * AGENDA *
         *********/
        internal static void ExibeMensagemAgendamento(bool v)
        {
            if(v) Console.WriteLine("\nAgendamento realizado com sucesso\n");
            else Console.WriteLine("\nErro: já existe uma consulta agendada neste horário.\n");
        }
        internal static void ExibeMensagemErroHorarioComercial()
        {
            Console.WriteLine("\nErro: horário inserido fora do horário comercial (08h às 19h)\n");
        }

        /*************
         * DATA/HORA *
         ************/
        internal static void ExibeMensagemErroHora()
        {
            Console.WriteLine("\nErro: hora inválida.\n");
        }
        internal static void ExibeMensagemErroData()
        {
            Console.WriteLine("\nErro: data inválida.\n");
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
            Console.WriteLine("\nErro: nome deve ter pelo menos 05 (cinco) caracteres.\n");
        }
    }
}
