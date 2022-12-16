using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    static class Controller
    {
        public static void Start()
        {
            Cliente c;
            ClienteForm cf;

            MENU:

            int escolhaMP;
            int? escolhaCP = null;
            int? escolhaA = null;

            escolhaMP = View.MenuPrincipal();

            switch (escolhaMP)
            {
                case 1: escolhaCP = View.MenuCadastroPaciente();   
                    break;
                case 2: escolhaA = View.MenuAgenda();
                    break;
                default: return;
            }

            if(escolhaCP != null )
            {
                switch (escolhaCP)
                {
                    case 1:
                    {
                        cf = View.CadastroCliente();
                        c = new(cf);
                        if (c != null) View.ExibeMensagemCadastroCliente(true);
                        else View.ExibeMensagemCadastroCliente(false);
                    }
                    break;
                    //...
                }
            }
            else if(escolhaA != null )
            {
                switch (escolhaA)
                {
                    //...
                }
            }


            // Ao final de toda execução,
            // voltaremos sempre ao menu principal
            // resetando os valores.
            goto MENU;
        }
    }
}
