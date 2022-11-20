using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Aluno_Q3
{
    internal class Curso
    {
        private String nome { get; set; }
        private List<Aluno> alunosDoCurso;
        private List<Turma> turmasDoCurso;

        public Curso(string nome)
        {
            this.nome = nome;
            alunosDoCurso = new();
            turmasDoCurso = new();
        }

        public Curso MatriculaAlunoCurso(Curso c, Aluno a)
        {
            //...

            return c;
        }
    }
}
