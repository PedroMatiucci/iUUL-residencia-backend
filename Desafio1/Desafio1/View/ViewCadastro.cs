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
        /*
         * Função para cadastramento de um paciente!
         */
        public static PacienteForm CadastroPaciente(GerenciaPaciente gerenciaPaciente)
        {
            PacienteForm pacienteForm = new();
            string? entrada;
            bool valido = true;

        //INSERÇÃO DE CPF PARA CADASTRO -> VALIDAÇÃO CPF VÁLIDO -> VALIDAÇÃO CPF EXISTENTE NO CADASTRO
        CPF:
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroCPF();

                entrada = InsereCPF();

                valido = ValidaPacienteForm.ValidaCPF(entrada);
            } while (!valido);

            if (gerenciaPaciente.ExistePaciente(entrada))
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


            return pacienteForm;
        }



        /*
         * Função para inserção de dados para agendamento
         * de uma consulta!
         */
        public static ConsultaForm InsereDadosConsulta(GerenciaPaciente gerenciaPaciente, Agenda agenda)
        {
            ConsultaForm consultaForm = new();
            string? entrada;
            bool valido = true;


            /* CPF DO PACIENTE */
            CPF:
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroCPF();

                entrada = InsereCPF();

                valido = ValidaPacienteForm.ValidaCPF(entrada);
            } while (!valido);

            consultaForm.CPF = entrada;

            if (!gerenciaPaciente.ExistePaciente(consultaForm.CPF))
            {
                ViewMensagens.ExibeMensagemCadastroPaciente(false);
                goto CPF;
            }

            if (gerenciaPaciente.ExisteAgendamento(consultaForm.CPF))
            {
                ViewMensagens.ExibeMensagemAgendamento(false);
                goto CPF;
            }


            /* DATA DA CONSULTA */
            do
            {
                if (!valido)
                    ViewMensagens.ExibeMensagemErroData();

                entrada = InsereDataConsulta();

                valido = ValidaAgendaForm.ValidaData(entrada);
            } while (!valido);

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

        public static string? InsereCPF()
        {
            Console.Write("\nCPF: ");
            string? entrada = Console.ReadLine();

            return entrada;
        }

        private static string? InsereDataConsulta()
        {
            Console.Write("Data da consulta: ");
            string? entrada = Console.ReadLine();

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

        internal static ConsultaForm InsereDadosCancelamentoConsulta()
        {
            ConsultaForm consultaForm = new();

            string? cpf, dataConsulta;
            bool v = true;

            do
            {
                if(!v)
                    ViewMensagens.ExibeMensagemErroCPF();
                cpf = InsereCPF();
                v = ValidaPacienteForm.ValidaCPF(cpf);
            } while (!v);

            consultaForm.CPF = cpf;

            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroData();
                dataConsulta = InsereDataConsulta();
                v = ValidaAgendaForm.ValidaData(dataConsulta);
            } while (!v);
            
            consultaForm.DataConsulta = dataConsulta;

            return consultaForm;
        }
    }
}
