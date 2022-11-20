using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class GerenciaAluno
    {
        public Turma InsereAluno(Turma t, Aluno a)
        {
            t.Alunos.Add(a);
            return t;
        }
        public Turma RemoveAluno(Turma t, Aluno a)
        {
            t.Alunos.Remove(a);
            return t;
        }

        public Aluno LancaNota(Aluno a,float p1,float p2)
        {
            a.P1 = p1;
            a.P2 = p2;
            a.PF = (p1 + p2) / 2;

            return a;
        }
    }
}
