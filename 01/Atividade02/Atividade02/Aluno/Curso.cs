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
        protected internal List<Turma> turmasDoCurso;

        
        public void RemoveTurmaCurso(Turma t)
        {
            for(int i = 0; i < this.turmasDoCurso.Count; i++)
            {
                var turma = this.turmasDoCurso[i];
                if (turma.Equals(t))
                    if (t.Alunos.Count == 0) // só será possível remover a Turma de um Curso caso não hajam alunos nela
                    {
                        this.turmasDoCurso.Remove(t);
                        Console.WriteLine("Turma "+t.Codigo+" removida com sucesso.");
                    }
                        
                    else
                        Console.WriteLine("Não foi possível excluir a turma "+t.Codigo+" pois ela possui alunos.");
            }
        }

        public void AdicionaTurmaCurso(Turma t)
        {
            this.turmasDoCurso.Add(t);
        }

        public void ImprimeTurmasDoCurso(Curso c)
        {
            Console.WriteLine("\nImprimindo dados do curso de: "+c.nome);
            Console.WriteLine("Quantidade de turmas: " + c.turmasDoCurso.Count);
            foreach (var turma in c.turmasDoCurso)
            {
                Console.WriteLine("\nCódigo da turma: "+turma.Codigo);
                Console.WriteLine("Quantidade de Alunos: "+ turma.Alunos.Count);
            }
        }

        public Curso(string nome)
        {
            this.nome = nome;
            alunosDoCurso = new();
            turmasDoCurso = new();
        }

        public void MatriculaAlunoCurso(Aluno a)
        {
            this.alunosDoCurso.Add(a);
        }
        public void RemoveAlunoCurso(Aluno a)
        {
            bool alunoMatriculado = false;
            //percorrendo todos os alunos de todas as turmas para ver se o "Aluno a" está em alguma
            foreach(var turma in this.turmasDoCurso)
                foreach(var aluno in turma.Alunos)
                    if (aluno.matricula == a.matricula)
                        alunoMatriculado = true; // se achou, ele está matriculado.

            //remover o aluno se ele não estiver em alguma turma
            if (!alunoMatriculado)
            {
                this.alunosDoCurso.Remove(a);
                Console.WriteLine("Aluno removido com sucesso.");
            }
                
            else
                Console.WriteLine("Não foi possível remover aluno pois ele está em alguma turma.");
        }
    }
}
