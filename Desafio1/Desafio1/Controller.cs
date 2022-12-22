namespace Consultorio
{
    internal static class Controller
    {
        public static void Start()
        {
            /*******************************************
             * Criaremos a lista de Consultas apenas uma
             * única vez durante a execução do programa.
             ******************************************/
            Agenda agenda = new();

        MENU:
            int escolhaMenuPrincipal;
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
                            Paciente p = ViewCadastro.CadastroPaciente();
                            ViewMensagens.ExibeMensagemCadastroPaciente();
                        }
                        break;
                    case 2:
                        {
                            long cpfRemover = ViewCadastro.InsereCPF(); // Inserir um CPF.
                            bool existePaciente = false;
                            bool temConsulta = false;

                            foreach (Paciente pacienteRemover in gp.Pacientes.ToList()) // Buscar o CPF.
                            {
                                if (pacienteRemover.CPF == cpfRemover)
                                {
                                    existePaciente = true;

                                    // Verificar se há algum atendimento marcado
                                    //...
                                    //if(verdadeiro)...
                                    // temConsulta == true;

                                    
                                    // Após as verificações, se existir o paciente
                                    // e se não tiver consulta, podemos excluí-lo.
                                    if (existePaciente && !temConsulta)
                                    {
                                        gp.Pacientes.Remove(pacienteRemover);
                                    }

                                    // Do contrário, se tiver consulta,
                                    // exibir mensagem de erro.
                                    else if(existePaciente && temConsulta)
                                    {
                                        ViewMensagens.ExibeMensagemRemocaoPacienteMarcado();
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
                            gp.Pacientes.Sort((a1, a2) => a1.CPF.CompareTo(a2.CPF));
                            ViewListagem.ExibeListaPacientes(gp.Pacientes);
                        }
                        break;
                    case 4:
                        {
                            // ordena a lista de pacientes utilizando o Nome como criterio de ordenacao 
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gp.Pacientes.Sort((a1, a2) => a1.Nome.CompareTo(a2.Nome));
                            ViewListagem.ExibeListaPacientes(gp.Pacientes);}
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
                            Consulta consulta = ViewCadastro.InsereDadosConsulta();
                            agenda.Consultas.Add(consulta);
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
