using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class Turma
    {
        protected internal List<Aluno> Alunos { get; set; }
        private String codigo = "TURMA";

        protected internal String Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                //gerando número aleatório
                Random r = new();
                String random = r.Next(0, 999).ToString();

                //removendo whitespaces do parâmetro e transformando em maiúsculo
                value = value.Trim().ToUpper();

                //gerando código "único"
                codigo = codigo + value + random;
            }
        }

        public Turma(String codigo, List<Aluno> alunos)
        {
            Alunos = new();
            this.Codigo = codigo;
            foreach (var aluno in alunos)
                this.InsereAlunoTurma(aluno);
        }

        public void InsereAlunoTurma(Aluno a)
        {
            // não pode haver aluno repetido na mesma turma
            for(int i = 0; i < this.Alunos.Count; i++)
            {
                var aluno = this.Alunos[i];
                if (aluno.Equals(a))
                    Console.WriteLine("Aluno já inserido na turma.");
                else
                    this.Alunos.Add(a);
            }
        }
        public void RemoveAlunoTurma(Aluno a)
        {
            this.Alunos.Remove(a);
        }
    }
}
