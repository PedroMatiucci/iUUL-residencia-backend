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
        private List<Aluno> alunos;
        private List<Turma> turmas;

        public Curso(string nome)
        {
            this.nome = nome;
            alunos = new();
            turmas = new();
        }
    }
}
