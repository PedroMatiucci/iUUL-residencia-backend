using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal static class ViewMensagens
    {
        public static void ExibeMensagemCadastroCliente()
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
    }
}
