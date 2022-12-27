using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.View
{
    internal static class ViewMensagens
    {
        /************
         * PACIENTE *
         ***********/
        public static void ExibeMensagemCadastroPaciente(bool v)
        {
            if (v) Console.WriteLine("\nPaciente cadastrado com sucesso!");
            else Console.WriteLine("\nErro: paciente não cadastrado.");
        }
        public static void ExibeMensagemRemocaoPaciente(bool v)
        {
            if (v) Console.WriteLine("\nPaciente excluído com sucesso!");
            else Console.WriteLine("\nErro: paciente não cadastrado.");
        }
        internal static void ExibeMensagemRemocaoPacienteAgendado()
        {
            Console.WriteLine("\nErro: paciente está agendado.");
        }
        public static void ExibeMensagemErroIdadePaciente()
        {
            Console.WriteLine("\nErro: paciente precisa ter pelo menos 13 anos.");
        }

        /**********
         * AGENDA *
         *********/
        internal static void ExibeMensagemAgendamento(bool v)
        {
            if(v) Console.WriteLine("\nAgendamento realizado com sucesso");
            else Console.WriteLine("\nErro: já existe uma consulta agendada neste horário.");
        }
        internal static void ExibeMensagemErroHorarioComercial()
        {
            Console.WriteLine("\nErro: horário inserido fora do horário comercial (08h às 19h)");
        }

        /*************
         * DATA/HORA *
         ************/
        internal static void ExibeMensagemErroHora()
        {
            Console.WriteLine("\nErro: hora inválida.");
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
            Console.WriteLine("\nErro: CPF inválido.");
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
