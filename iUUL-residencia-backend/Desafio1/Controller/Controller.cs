using Consultorio.DB;
using Consultorio.Form;
using Consultorio.Model;
using Consultorio.Model.Daos;
using Consultorio.View;

namespace Consultorio.Controller
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
            PacienteController gerenciaPaciente = new();
            ConsultasController consultasController = new();

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
                    case 1:
                        {
                            PacienteForm pacienteForm = new();

                            pacienteForm = ViewCadastro.CadastroPaciente(pacienteForm,gerenciaPaciente);

                            Paciente p = new(pacienteForm.Nome, pacienteForm.CPF, DateTime.Parse(pacienteForm.DataNascimento));

                            gerenciaPaciente.AdicionaPaciente(p);
                            

                            ViewMensagens.ExibeMensagemCadastroPaciente();
                        }
                        break;
                    case 2:
                        {
                            PacienteForm pf = new();
                            var cpfRemover = ViewCadastro.InsereCPFValidoExistente(gerenciaPaciente,pf); // Inserir um CPF.

                            try
                            {
                                gerenciaPaciente.RemovePaciente(cpfRemover);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemRemocaoPaciente(false);
                                break;
                            }
                            ViewMensagens.ExibeMensagemRemocaoPaciente(true);
                        }
                        break;
                    case 3:
                        {
                            //Recebe a lista ordenada por CPF e repassa para a VIEW printar
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.RetornaPacientesPorCPF());
                        }
                        break;
                    case 4:
                        {
                            //Recebe a lista ordenada por Nome e repassa para a VIEW printar
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.RetornaPacientesPorNome());
                        }
                        break;
                   default: break;
                }
            }

            else if (escolhaAgenda != null)
            {
                switch (escolhaAgenda)
                {
                    case 1:
                        {
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosConsulta(gerenciaPaciente, consultaForm,pf);

                            //Verificar se o cpf inserido para consulta está cadastrado no sistema
                            Paciente? paciente = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                            if (paciente == null)
                            {
                                ViewMensagens.ExibeMensagemErroCPFCadastrado(false);
                                break;
                            }

                            // Se estiver, verificar sobreposição de consultas
                            Consulta consulta = new(paciente,
                                DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta)),
                                consultaForm.HoraInicial, consultaForm.HoraFinal);
                            try
                            {
                               paciente.Consulta = consulta;
                            }
                            catch
                            {
                                // Exibir mensagem de erro
                                ViewMensagens.ExibeMensagemAgendamento(false);
                                break;
                            }

                            // Adicionando consulta na agenda
                            consultasController.AdicionaConsulta(consulta.DataConsulta,consulta.HoraInicial ,consulta.HoraFinal,paciente.CPF);

                            // Exibir mensagem de sucesso
                            ViewMensagens.ExibeMensagemAgendamento(true);
                        }
                        break;
                    case 2:
                        {
                            ConsultaForm consultaForm = new();
                            PacienteForm pf = new();
                            consultaForm = ViewCadastro.InsereDadosCancelamentoConsulta(gerenciaPaciente,consultaForm,pf);

                            try
                            {
                                consultasController.RemoveConsulta(consultaForm);
                            }
                            catch
                            {
                                ViewMensagens.ExibeMensagemCancelarConsulta(false);
                                break;
                            }

                            // Se o try for realizado com sucesso,
                            // removemos a consulta associada ao paciente.
                            Paciente? pacienteRemoverConsulta = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                            
                            if(pacienteRemoverConsulta != null)
                                pacienteRemoverConsulta.Consulta = null;

                            ViewMensagens.ExibeMensagemCancelarConsulta(true);
                        }
                        break;
                    case 3:
                        {
                            int escolha = vm.MenuListagemAgenda();
                            switch(escolha)
                            {
                                case 1:
                                    {

                                        ViewListagem.ExibeAgenda(consultasController.RetornaConsultas());
                                    }
                                    break;
                                case 2:
                                    {
                                        var datas = ViewCadastro.InsereDataInicialFinalValida();
                                        ViewListagem.ExibeAgendaPeriodo(datas, consultasController.RetornaConsultas());
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
