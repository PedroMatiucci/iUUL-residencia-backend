uusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Consultorio_Odontologico.model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Patiente> Patientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AgendaConsultorioOdontologicoDb;Trusted_Connection=True;");
        }
    }
}



