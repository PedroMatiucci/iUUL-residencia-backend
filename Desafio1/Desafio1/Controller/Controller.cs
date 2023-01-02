using Consultorio.Form;
using Consultorio.Model;
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
            Agenda agenda = new();
            GerenciaPaciente gerenciaPaciente = new();

            int escolhaMenuPrincipal;
            int? escolhaCadastroPaciente;
            int? escolhaAgenda;
        MENU:
            escolhaCadastroPaciente = null;
            escolhaAgenda = null;

            escolhaMenuPrincipal = ViewMenu.MenuPrincipal();

            switch (escolhaMenuPrincipal)
            {
                case 1:
                    escolhaCadastroPaciente = ViewMenu.MenuCadastroPaciente();
                    break;
                case 2:
                    escolhaAgenda = ViewMenu.MenuAgenda();
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

                            gerenciaPaciente.Pacientes.Add(p);

                            ViewMensagens.ExibeMensagemCadastroPaciente();
                        }
                        break;
                    case 2:
                        {
                            var cpfRemover = ViewCadastro.InsereCPFValidoExistente(gerenciaPaciente); // Inserir um CPF.

                            if (gerenciaPaciente.RemovePaciente(cpfRemover))
                            {
                                ViewMensagens.ExibeMensagemRemocaoPaciente(true);
                                break;
                            }
                            
                            ViewMensagens.ExibeMensagemRemocaoPaciente(false);
                            break;
                        }
                    case 3:
                        {
                            // ordena a lista de pacientes utilizando o Cpf como criterio de ordenacao
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.CPF.CompareTo(a2.CPF));
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
                        }
                        break;
                    case 4:
                        {
                            // ordena a lista de pacientes utilizando o Nome como criterio de ordenacao
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gerenciaPaciente.Pacientes.Sort((a1, a2) => a1.Nome.CompareTo(a2.Nome));
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);
                        }
                        break;
                   // default: return;
                }
            }

            else if (escolhaAgenda != null)
            {
                switch (escolhaAgenda)
                {
                    case 1:
                        {
                            ConsultaForm consultaForm = new();
                            consultaForm = ViewCadastro.InsereDadosConsulta(gerenciaPaciente, agenda, consultaForm);
                            
                            // Método que retorna o objeto paciente a partir do CPF
                            Paciente? paciente = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                            if (paciente == null)
                            {
                                ViewMensagens.ExibeMensagemErroCPFCadastrado(false);
                                break;
                            }

                            Consulta consulta = new(consultaForm.CPF,
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
                            Agenda.Consultas.Add(consulta);

                            // Exibir mensagem de sucesso
                            ViewMensagens.ExibeMensagemAgendamento(true);
                        }
                        break;
                    case 2:
                        {
                            ConsultaForm consultaForm = new();
                            consultaForm = ViewCadastro.InsereDadosCancelamentoConsulta(gerenciaPaciente,consultaForm);

                            if (!agenda.RemoveConsulta(consultaForm))
                                ViewMensagens.ExibeMensagemCancelarConsulta(false);
                            else
                            {
                                Paciente? pacienteRemoverConsulta = gerenciaPaciente.RetornaPaciente(consultaForm.CPF);
                                if (pacienteRemoverConsulta.Consulta != null)
                                    pacienteRemoverConsulta.Consulta = null;
                                ViewMensagens.ExibeMensagemCancelarConsulta(true);
                            }
                                
                        }
                        break;
                    case 3:
                        {
                            int escolha = ViewMenu.MenuListaAgenda();
                            switch(escolha)
                            {
                                case 1:
                                    {
                                        ViewListagem.ExibeAgenda(gerenciaPaciente);
                                    }
                                    break;
                                case 2:
                                    {
                                        var datas = ViewCadastro.InsereDataInicialFinalValida();
                                        ViewListagem.ExibeAgendaPeriodo(agenda, datas);
                                    }
                                    break;
                                default: break;
                            }
                        }
                        break;
                }
            }

            // Ao final de toda execução,
            // voltaremos sempre ao menu principal
            // resetando os valores das escolhas.
            goto MENU;
        }
    }
}
