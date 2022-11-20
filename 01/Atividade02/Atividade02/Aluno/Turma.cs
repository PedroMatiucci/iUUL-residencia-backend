using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Turma : Cursa
    {
        protected internal List<Aluno> Alunos { get; set; }
        private String codigo { get; set; }

        public Turma(String codigo, List<Aluno> alunos)
        {
            this.codigo = codigo;
            Alunos = new ();
            foreach(var aluno in alunos)
            {
                Alunos.Add(aluno);
            }
        }

        public Turma InsereAlunoTurma(Turma t, Aluno a)
        {
            t.Alunos.Add(a);
            return t;
        }
        public Turma RemoveAlunoTurma(Turma t, Aluno a)
        {
            t.Alunos.Remove(a);
            return t;
        }
    }
}
