using Consultorio.DB;
using Consultorio.Util;

namespace Consultorio.Model.Daos
{
    internal class ConsultaDAO : IConsultaDAO, IDisposable
    {

        private ApplicationDbContext contexto;

        public ConsultaDAO()
        {
            this.contexto = new ApplicationDbContext();
        }

        public void Adicionar(Consulta c)
        {
            contexto.Add(c);
            contexto.SaveChanges();
        }


        public void Remover(Consulta c)
        {
            contexto.Remove(c);
            contexto.SaveChanges();
        }

        public IList<Consulta> RetornaConsultas()
        {
            return contexto.Consultas.ToList();
        }

        public IList<Paciente> RetornaConsultasPeriodo()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
