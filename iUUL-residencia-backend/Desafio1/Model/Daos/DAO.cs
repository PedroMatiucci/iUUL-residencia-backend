using Consultorio.DB;
using Consultorio.Util;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Model.Daos
{
    internal class DAO : IPacienteDAO,IConsultaDAO, IDisposable
    {

        private ApplicationDbContext contexto;

        public DAO()
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

        public List<Paciente> RetornaPacientes()
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

        public List<Consulta> RetornaConsultas()
        {
            return contexto.Consultas.Include(c => c.Paciente).ToList();
        }

        public List<Paciente> RetornaConsultasPeriodo()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
