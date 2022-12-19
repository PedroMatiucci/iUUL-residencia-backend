namespace Consultorio
{
    static class Controller
    {
        public static void Start()
        {
            Cliente c;
            ClienteForm cf;
            // Criaremos a lista de clientes apenas uma
            // única vez durante a execução do programa.
            GerenciaCliente gc = new();

            MENU:

            int escolhaMP;
            int? escolhaCP = null;
            int? escolhaA = null;

            escolhaMP = View.MenuPrincipal();

            switch (escolhaMP)
            {
                case 1:
                    escolhaCP = View.MenuCadastroPaciente();
                    break;
                case 2:
                    escolhaA = View.MenuAgenda();
                    break;
                default: return;
            }

            if (escolhaCP != null)
            {
                switch (escolhaCP)
                {
                    case 1:
                        {
                            cf = View.CadastroCliente();
                            c = new(cf);
                            // Adicionando cliente recém-criado na lista de clientes.
                            gc.Clientes.Add(c);
                            if (c != null) View.ExibeMensagemCadastroCliente(true);
                            else View.ExibeMensagemCadastroCliente(false);
                        }
                        break;
                    case 2:
                        {
                            long cpfRemover = View.RemoveCliente();
                            bool verifica = false;
                            foreach (Cliente clienteRemover in gc.Clientes.ToList())
                            {
                                if (clienteRemover.CPF == cpfRemover)
                                {
                                    gc.Clientes.Remove(clienteRemover);//veriricar se tem atendimento marcado
                                    verifica = true;
                                    //remover os atendiemtos tambem
                                }
                            }
                            View.ExibeMensagemErroRemocao(verifica);
                        }
                        break;
                        //...
                }
            }
            else if (escolhaA != null)
            {
                switch (escolhaA)
                {
                    //...
                }
            }


            // Ao final de toda execução,
            // voltaremos sempre ao menu principal
            // resetando os valores das escolhas.
            goto MENU;
        }
    }
}
