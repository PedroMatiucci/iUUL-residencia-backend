using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    static class ValidaMenusView
    {
        internal static bool ValidaEscolhaAte3(int escolha)
        {
            return (escolha >= 1 && escolha <= 3);
        }
        internal static bool ValidaEscolhaAte5(int escolha)
        {
            return (escolha >= 1 && escolha <= 5);
        }
        internal static bool ValidaEscolhaAte4(int escolha)
        {
            return (escolha >= 1 && escolha <= 4);
        }
    }
}
