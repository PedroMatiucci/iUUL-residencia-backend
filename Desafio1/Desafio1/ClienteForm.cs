using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consultorio
{
    public class ClienteForm
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? DataNascimento { get; set; }
    
        public ClienteForm() { }
    }
}
