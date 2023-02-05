using Consultorio.DB;
using Consultorio.Util;

namespace Consultorio.Model.Daos
{
    internal class PacienteDAO : IPacienteDAO, IDisposable
    {

        private ApplicationDbContext contexto;

        public PacienteDAO()
        {
                this.contexto = new ApplicationDbContext();
        }
        public void Adicionar(Paciente p)
        {
            contexto.Pacientes.Add(p);
            contexto.SaveChanges();

        }
        public void Remover(Paciente p)
        {
            contexto.Pacientes.Remove(p);
            contexto.SaveChanges();
        }

        public List<Paciente> ListarPorCpf()
        {
            return contexto.Pacientes.OrderBy(p => p.CPF).ToList();
        }

        public List<Paciente> ListarPorNome()
        {
            return contexto.Pacientes.OrderBy(p => p.Nome).ToList();
        }

        public IList<Paciente> RetornaPacientes()
        {
            return contexto.Pacientes.ToList();

        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
