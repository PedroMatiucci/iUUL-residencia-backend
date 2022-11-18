using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Turma : Cursa
    {
        List<Aluno> Alunos { get; set; }

        public Turma(Aluno a)
        {
            this.Alunos = new List<Aluno> { a };
        }
    }
}
