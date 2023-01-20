using System;
using ConsultorioDB.dao;
using ConsultorioDB.model;
using ConsultorioDB.view.forms;

namespace ConsultorioDB
{
    internal static class Controller
    {
        public static void Start()
        {
            /*******************************************
             * Criaremos a lista de Consultas e Pacientes
             * apenas uma única vez durante a execução
             * do programa.
             ******************************************/
            Agenda agenda = new();
            ListaPaciente listaPacientes = new();

            int escolhaMenuPrincipal;
            int? escolhaCadastroPaciente;
            int? escolhaAgenda;
            var vm = new ViewMenu();
        MENU:
            escolhaCadastroPaciente = null;
            escolhaAgenda = null;

            escolhaMenuPrincipal = vm.MenuPrincipal();

            switch (escolhaMenuPrincipal)
            {
                case 1:
                    escolhaCadastroPaciente = vm.MenuCadastroPaciente();
                    break;
                case 2:
                    escolhaAgenda = vm.MenuAgenda();
                    break;
                default: return;
            }

            if (escolhaCadastroPaciente != null)
            {
                switch (escolhaCadastroPaciente)
                {
                    /**********************
                     * CADASTRAR PACIENTE *
                     *********************/
                    case 1:
                        {
                            PacienteForm pacienteForm = new();

                            pacienteForm = ViewCadastro.CadastroPaciente(pacienteForm,listaPacientes);

                            Paciente p = new(pacienteForm.Nome, pacienteForm.CPF, DateTime.Parse(pacienteForm.DataNascimento));

                            listaPacientes.Pacientes.Add(p);

                            ViewMensagens.ExibeMensagemCadastroPaciente();
                        }
                        break;
                    /*******************
                    * EXCLUIR PACIENTE *
                    *******************/
                    case 2:
                        {
                            PacienteForm pf = new();
                            var cpfRemover = ViewCadastro.InsereCPFValidoExistente(listaPacientes,pf); // Inserir um CPF.

                            try
                            {
                                PacienteDAO.RemovePaciente(cpfRemover,listaPacientes.Pacientes);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemRemocaoPaciente(false);
                                break;
                            }
                            ViewMensagens.ExibeMensagemRemocaoPaciente(true);
                        }
                        break;
                    /*************************
                     * LISTAR PACIENTE (CPF) *
                     ************************/
                    case 3:
                        {
                            listaPacientes.Pacientes.Sort((p1, p2) => p1.CPF.CompareTo(p2.CPF));
                            ViewListagem.ExibeListaPacientes(listaPacientes.Pacientes);
                        }
                        break;
                    /*************************
                     * LISTAR PACIENTE (Nome) *
                     ************************/
                    case 4:
                        {
                            listaPacientes.Pacientes.Sort((p1, p2) => p1.Nome.CompareTo(p2.Nome));
                            ViewListagem.ExibeListaPacientes(listaPacientes.Pacientes);
                        }
                        break;
                   default: break;
                }
            }

            else if (escolhaAgenda != null)
            {
                switch (escolhaAgenda)
                {
                    /******************
                     * CRIAR CONSULTA *
                     *****************/
                    case 1:
                        {
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosConsulta(listaPacientes, consultaForm,pf);

                            //Verificar se o cpf inserido para consulta está cadastrado no sistema
                            Paciente? paciente = PacienteDAO.RetornaPaciente(consultaForm.CPF,listaPacientes.Pacientes);
                            if (paciente == null)
                            {
                                ViewMensagens.ExibeMensagemErroCPFCadastrado(false);
                                break;
                            }

                            // Se estiver, verificar sobreposição de consultas
                            Consulta consulta = new(consultaForm.CPF,
                                DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta)),
                                consultaForm.HoraInicial, consultaForm.HoraFinal);
                            try
                            {
                                paciente.MarcaConsulta(consulta,agenda);
                            }
                            catch
                            {
                                // Exibir mensagem de erro
                                ViewMensagens.ExibeMensagemAgendamento(false);
                                break;
                            }

                            // Adicionando consulta na agenda
                            agenda.Consultas.Add(consulta);

                            // Exibir mensagem de sucesso
                            ViewMensagens.ExibeMensagemAgendamento(true);
                        }
                        break;
                    /********************
                     * EXCLUIR CONSULTA *
                     *******************/
                    case 2:
                        {
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosCancelamentoConsulta(listaPacientes,consultaForm,pf);

                            try
                            {
                                consultaForm.RemoveConsulta(agenda);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemCancelarConsulta(false);
                                break;
                            }

                            // Se o try for realizado com sucesso,
                            // removemos a consulta associada ao paciente.
                            Paciente? pacienteRemoverConsulta = PacienteDAO.RetornaPaciente(consultaForm.CPF,listaPacientes.Pacientes);
                            
                            if(pacienteRemoverConsulta != null)
                                pacienteRemoverConsulta.Consulta = null;

                            ViewMensagens.ExibeMensagemCancelarConsulta(true);
                        }
                        break;
                    /*******************
                     * LISTAR CONSULTA *
                     ******************/
                    case 3:
                        {
                            int escolha = vm.MenuListagemAgenda();
                            switch(escolha)
                            {
                                //COMPLETA
                                case 1:
                                    {
                                        // Aqui entra um dao...
                                        ViewListagem.ExibeAgenda(listaPacientes);
                                    }
                                    break;
                                //PERÍODO
                                case 2:
                                    {
                                        var datas = ViewCadastro.InsereDataInicialFinalValida();
                                        // Aqui entra um dao...
                                        ViewListagem.ExibeAgendaPeriodo(agenda, datas, listaPacientes);
                                    }
                                    break;
                                default: break;
                            }
                        }
                        break;
                    default : break;
                }
            }

            // Ao final de toda execução,
            // voltaremos sempre ao menu principal
            // resetando os valores das escolhas.
            goto MENU;
        }
    }
}
