namespace Consultorio
{
    internal static class Controller
    {
        public static void Start()
        {
            Cliente c;
            ClienteForm cf;
            // Criaremos a lista de clientes apenas uma
            // única vez durante a execução do programa.
            GerenciaCliente gc = new();
            Agenda a = new();

            MENU:

            int escolhaMP;
            int? escolhaCP = null;
            int? escolhaA = null;

            escolhaMP = ViewMenu.MenuPrincipal();

            switch (escolhaMP)
            {
                case 1: escolhaCP = ViewMenu.MenuCadastroPaciente();
                    break;
                case 2: escolhaA = ViewMenu.MenuAgenda();
                    break;
                default: return;
            }

            if (escolhaCP != null)
            {
                switch (escolhaCP)
                {
                    case 1:
                        {
                            cf = ViewCadastro.CadastroCliente();
                            c = new(cf);

                            // Adicionando cliente recém-criado na lista de clientes.
                            gc.Clientes.Add(c);

                            ViewMensagens.ExibeMensagemCadastroCliente();
                        }
                        break;
                    case 2:
                        {
                            long cpfRemover = ViewCadastro.InsereCPF(); // Inserir um CPF.
                            bool existePaciente = false;
                            bool temConsulta = false;

                            foreach (Cliente pacienteRemover in gc.Clientes.ToList()) // Buscar o CPF.
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
                                        gc.Clientes.Remove(pacienteRemover);
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
                            gc.Clientes.Sort((a1, a2) => a1.CPF.CompareTo(a2.CPF));
                            ViewListagem.ExibeListaPacientes(gc.Clientes);
                        }
                        break;
                    case 4:
                        {
                            // ordena a lista de pacientes utilizando o Nome como criterio de ordenacao 
                            //Depois Retorna para o view a lista ordenada para ser printada
                            gc.Clientes.Sort((a1, a2) => a1.Nome.CompareTo(a2.Nome));
                            ViewListagem.ExibeListaPacientes(gc.Clientes);}
                        break;
                    default:return;
                }
            }

            else if (escolhaA != null)
            {
                switch (escolhaA)
                {
                    case 1:
                        {
                            if (a.AgendarConsulta())
                            {

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
