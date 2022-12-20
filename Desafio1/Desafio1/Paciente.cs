using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class Paciente
    {
        public string Nome { get; private set; }
        public long CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Paciente(PacienteForm cf)
        {
            this.Nome = cf.Nome;
            this.CPF = long.Parse(cf.CPF);
            this.DataNascimento = DateTime.Parse(cf.DataNascimento);
        }
    }
}
