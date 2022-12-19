using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    public class GerenciaCliente
    {
        public List<Cliente> Clientes { get; private set;}

        public GerenciaCliente()
        {
            Clientes= new List<Cliente>();
        }
    }
}
