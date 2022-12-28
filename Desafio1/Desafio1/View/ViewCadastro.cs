using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Controller;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.Validators;

namespace Consultorio.View
{
    internal static class ViewCadastro
    {
        /********************************************
         * Função para cadastramento de um paciente!
         *******************************************/
        public static PacienteForm CadastroPaciente(PacienteForm pacienteForm, GerenciaPaciente gerenciaPaciente)
        {
            string? entrada;
            bool valido = true;

            /* CPF */
            //INSERÇÃO DE CPF PARA CADASTRO -> VALIDAÇÃO CPF VÁLIDO -> VALIDAÇÃO CPF EXISTENTE NO CADASTRO
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroCPFCadastrado();

                entrada = InsereCPFValido();

                valido = gerenciaPaciente.ExistePaciente(entrada);
            } while (valido);

            pacienteForm.CPF = entrada;


            /* NOME */
            entrada = InsereNomeValido();
            pacienteForm.Nome = entrada;


            /* DATA DE NASCIMENTO */
            entrada = InsereDataNascimentoValido();
            pacienteForm.DataNascimento = entrada;


            return pacienteForm;
        }

        private static string InsereDataNascimentoValido()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();

                Console.Write("Data de Nascimento: ");
                entrada = Console.ReadLine();

                v = ValidaPacienteForm.IsDataNascimento(entrada);
            } while (!v);

            return entrada;
        }



        /**************************************************
         * Função para inserção de dados para agendamento
         * de uma consulta!
         *************************************************/
        public static ConsultaForm InsereDadosConsulta(GerenciaPaciente gerenciaPaciente, Agenda agenda, ConsultaForm consultaForm)
        {
            string? entrada;
            bool valido = true;
            bool existePaciente = true, existeAgendamento = true;


            /* CPF DO PACIENTE */
            do
            {
                entrada = InsereCPFValido();

                existePaciente = gerenciaPaciente.ExistePaciente(entrada);

                if (!existePaciente)
                    ViewMensagens.ExibeMensagemCadastroPaciente(false);

                /***************************************************/
                /* VALIDAR SE JÁ EXISTE UMA CONSULTA PARA ESSE CPF */
                /***************************************************/
                if (existePaciente)
                    existeAgendamento = gerenciaPaciente.ExisteAgendamento(entrada);


                if (existeAgendamento)
                    ViewMensagens.ExibeMensagemAgendamento(true);

            } while (!existePaciente && existeAgendamento);

            consultaForm.CPF = entrada;


            /* DATA DA CONSULTA */
            entrada = InsereDataConsultaValida();
            consultaForm.DataConsulta = entrada;


            /* HORAS INICIAL E FINAL */
            var horasInicialFinal = new string[2];
            HORA:
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroHora();

                horasInicialFinal = InsereHoraInicialFinal();

                valido = ValidaAgendaForm.ValidaHora(horasInicialFinal);
            } while (!valido);

            if (!ValidaAgendaForm.HorarioValido(horasInicialFinal))
            {
                ViewMensagens.ExibeMensagemErroHorarioComercial();
                goto HORA;
            }
            if (!ValidaAgendaForm.HorarioDisponivel(horasInicialFinal, agenda))
            {
                ViewMensagens.ExibeMensagemAgendamento(false);
                goto HORA;
            }

            consultaForm.HoraInicial = horasInicialFinal[0];
            consultaForm.HoraFinal = horasInicialFinal[1];

            return consultaForm;
        }

        private static string[] InsereHoraInicialFinal()
        {
            string[] horasInicialFinal = new string[2];

            Console.Write("Hora inicial: ");
            string? entrada = Console.ReadLine();
            horasInicialFinal[0] = entrada;

            Console.Write("Hora final: ");
            entrada = Console.ReadLine();
            horasInicialFinal[1] = entrada;

            return horasInicialFinal;
        }

        public static string InsereNomeValido()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroNome();

                Console.Write("Nome: ");
                entrada = Console.ReadLine();

                v = ValidaPacienteForm.IsNome(entrada);
            } while (!v);

            return entrada;
        }

        public static string InsereCPFValido()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroCPF();

                Console.Write("\nCPF: ");
                entrada = Console.ReadLine();

                v = ValidaPacienteForm.ValidaCPF(entrada);
            } while (!v);

            return entrada;
        }

        private static string InsereDataConsultaValida()
        {
            bool v = true;
            string? entrada;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();

                Console.Write("Data da consulta: ");
                entrada = Console.ReadLine();

                v = ValidaAgendaForm.ValidaDataMarcacaoConsulta(entrada);
            } while (!v);

            return entrada;
        }

        internal static string[] InsereDataInicialFinalValida()
        {
            string[] dataInicialFinal = new string[2];

            string? entrada;
            do
            {
                Console.Write("Data inicial: ");
                entrada = Console.ReadLine();
            } while (!ValidaAgendaForm.ValidaData(entrada));
            
            dataInicialFinal[0] = entrada;

            do
            {
                Console.Write("Data final: ");
                entrada = Console.ReadLine();
            } while (!ValidaAgendaForm.ValidaData(entrada));
            
            dataInicialFinal[1] = entrada;

            return dataInicialFinal;
        }

        internal static ConsultaForm InsereDadosCancelamentoConsulta(ConsultaForm consultaForm)
        {
            string? entrada;

            entrada = InsereCPFValido();
            consultaForm.CPF = entrada;

            entrada = InsereDataConsultaValida();
            consultaForm.DataConsulta = entrada;

            return consultaForm;
        }
    }
}
