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
        public static Paciente CadastroPaciente()
        {
            PacienteForm pacienteForm = new();
            Paciente paciente;
            string? entrada;
            bool valido = true;
            bool cpfValido = true;
            bool conversaoValida = true;

            //INSERÇÃO DE CPF PARA CADASTRO -> VALIDAÇÃO CPF VÁLIDO -> VALIDAÇÃO CPF EXISTENTE NO CADASTRO
            CPF:
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroCPF();

                entrada = InsereCPF();

                valido = ValidaPacienteForm.ValidaCPF(entrada);
            } while (!valido);

            if (gerenciaPaciente.ProcuraPaciente(entrada))
            {
                ViewMensagens.ExibeMensagemErroCPFCadastrado();
                goto CPF;
            }

            pacienteForm.CPF = entrada;

            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroNome();
                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                valido = ValidaPacienteForm.IsNome(entrada);
            } while (!valido);

            pacienteForm.Nome = entrada;

            do
            {
                if (valido == false)
                    ViewMensagens.ExibeMensagemErroData();
                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                valido = ValidaPacienteForm.IsDataNascimento(entrada);
            } while (!valido);

            pacienteForm.DataNascimento = entrada;

            paciente = new(pacienteForm.Nome, long.Parse(pacienteForm.CPF), DateTime.Parse(pacienteForm.DataNascimento));

            return paciente;
        }
        
        /*
         * Função para inserção de dados para agendamento
         * de uma consulta!
         */
        public static Consulta InsereDadosConsulta()
        {
            ConsultaForm consultaForm = new();
            string? entrada;
            bool valido = true;

            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroCPF();

                entrada = InsereCPF();

                valido = ValidaPacienteForm.ValidaCPF(entrada);
            } while (!valido);
            
            consultaForm.CPF = entrada;

            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemAgendamento(valido);

                entrada = InsereDataConsulta();

                valido = ValidaAgendaForm.ValidaData(entrada);
            } while (!valido);
            
            consultaForm.DataConsulta = entrada;

            /*
            // terminar este último...
            string[] horasInicialFinal;
            horasInicialFinal = InsereHoraInicialFinal(c.Agenda);
            consultaForm.HoraInicial = horasInicialFinal[0];
            consultaForm.HoraFinal = horasInicialFinal[1];

            ValidaAgendaForm.HoraValida();


            Consulta consulta;

            return consulta;
            */
        }

        private static string[] InsereHoraInicialFinal()
        {
            string[] horasInicialFinal = new string[2];
        
            Console.WriteLine("Hora inicial: ");
            string? entrada = Console.ReadLine();
            horasInicialFinal[0] = entrada;
            
            Console.WriteLine("Hora final: ");
            entrada = Console.ReadLine();
            horasInicialFinal[1] = entrada;

            return horasInicialFinal;
        }

        public static string? InsereCPF()
        {
            Console.WriteLine("CPF: ");
            string? entrada = Console.ReadLine();

            return entrada;
        }

        private static string? InsereDataConsulta()
        {
            Console.WriteLine("Data da consulta: ");
            string? entrada = Console.ReadLine();
            
            return entrada;
        }
    }
}
