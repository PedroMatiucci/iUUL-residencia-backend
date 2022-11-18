using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    abstract class GerenciaAluno
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

        public Aluno LancaNota(Aluno a,int nota)
        {


            return a;
        }

        public void ImprimeTurma(Turma turma)
        {
            
        }
    }
}
