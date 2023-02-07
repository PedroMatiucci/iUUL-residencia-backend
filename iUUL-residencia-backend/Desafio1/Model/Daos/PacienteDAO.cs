using Consultorio.DB;
using Consultorio.Util;

namespace Consultorio.Model.Daos
{
    internal class PacienteDAO : IPacienteDAO,IConsultaDAO, IDisposable
    {

        private ApplicationDbContext contexto;

        public PacienteDAO()
        {
                this.contexto = new ApplicationDbContext();
        }
        public void AdicionarPaciente(Paciente p)
        {
            contexto.Pacientes.Add(p);
            contexto.SaveChanges();

        }
        public void RemoverPaciente(Paciente p)
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

        public void AdicionarConsulta(DateOnly data, string horaInicial, string horaFinal, string cpf)
        {
            Paciente? paciente = contexto.Pacientes.Where(p => p.CPF == cpf).FirstOrDefault();
            Consulta consulta = new(paciente, data, horaInicial, horaFinal);
            contexto.Consultas.Add(consulta);
            contexto.SaveChanges();
        }


        public void RemoverConsulta(Consulta c)
        {
            contexto.Consultas.Remove(c);
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
