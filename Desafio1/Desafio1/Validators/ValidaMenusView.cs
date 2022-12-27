using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Validators
{
    internal static class ValidaMenusView
    {
        internal static bool ValidaEscolha(string? entrada, int tipoMenu)
        {
            if(entrada == null) return false;

            int escolha;
            try
            {
                escolha = int.Parse(entrada);
            }
            catch
            {
                return false;
            }

            switch (tipoMenu)
            {
                case 3:
                    {
                        return escolha >= 1 && escolha <= tipoMenu;
                    }
                case 4:
                    {
                        return escolha >= 1 && escolha <= tipoMenu;
                    }
                case 5:
                    {
                        return escolha >= 1 && escolha <= tipoMenu;
                    }
                default:return false;
            }
        }
    }
}
