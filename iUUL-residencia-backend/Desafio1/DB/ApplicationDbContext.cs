using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.DB.Mappings;
using Consultorio.Model;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.DB
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Paciente> Patientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Agenda> Agenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AgendaConsultorioOdontologicoDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new ConsultaMap());
        }
    }
}



