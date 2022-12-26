namespace Consultorio
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
        MENU:
            int? escolhaCadastroPaciente = null;
            int? escolhaAgenda = null;

            escolhaMenuPrincipal = ViewMenu.MenuPrincipal();

            switch (escolhaMenuPrincipal)
            {
                case 1: escolhaCadastroPaciente = ViewMenu.MenuCadastroPaciente();
                    break;
                case 2: escolhaAgenda = ViewMenu.MenuAgenda();
                    break;
                default: return;
            }

            if (escolhaCadastroPaciente != null)
            {
                switch (escolhaCadastroPaciente)
                {
                    case 1:
                        {
                            Paciente p = ViewCadastro.CadastroPaciente(gerenciaPaciente);
                            gerenciaPaciente.Pacientes.Add(p);
                            ViewMensagens.ExibeMensagemCadastroPaciente(true);
                        }
                        break;
                    case 2:
                        {
                            long cpfRemover = long.Parse(ViewCadastro.InsereCPF()); // Inserir um CPF.
                            bool existePaciente = false;

                            foreach (Paciente pacienteRemover in gerenciaPaciente.Pacientes.ToList()) // Buscar o CPF.
                            {
                                if (pacienteRemover.CPF == cpfRemover)//Verifica se existe um Paciente com este CPF
                                {
                                    existePaciente = true;
                                    if (pacienteRemover.Consulta == null)//Se existir o paciente verifica se ele tem uma consulta agendada
                                    {
                                        gerenciaPaciente.Pacientes.Remove(pacienteRemover);//remove o paciente 
                                    }
                                    else
                                    {
                                        ViewMensagens.ExibeMensagemRemocaoPacienteAgendado();//Mensagem de erro caso o paciente tenha uma consulta futura agendada
                                    }
                                }
                                ViewMensagens.ExibeMensagemRemocaoPaciente(existePaciente);
                            }
                        }
                        break;
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
                            ViewListagem.ExibeListaPacientes(gerenciaPaciente.Pacientes);}
                        break;
                    default:return;
                }
            }

            else if (escolhaAgenda != null)
            {
                switch (escolhaAgenda)
                {
                    case 1:
                        {
                            ConsultaForm consultaForm = ViewCadastro.InsereDadosConsulta(gerenciaPaciente, agenda);

                            Consulta consulta = new(long.Parse(consultaForm.CPF),
                                DateOnly.FromDateTime(DateTime.Parse(consultaForm.DataConsulta)),
                                int.Parse(consultaForm.HoraInicial), int.Parse(consultaForm.HoraFinal));

                            agenda.Consultas.Add(consulta);
                            ViewMensagens.ExibeMensagemAgendamento(true);
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
