using Consultorio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.DB.Mappings
{
    internal class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasOne(p => p.Consulta)
            .WithOne(c => c.Paciente)
            .HasForeignKey<Consulta>(c => c.PacienteId);

        }
    }
}
