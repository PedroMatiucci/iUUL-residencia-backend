using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Aluno : Cursa
    {
        public String matricula;
        public String nome;

        public Aluno(String matricula, String nome)
        {
            this.matricula = matricula;
            this.nome = nome;
        }
    }
}
