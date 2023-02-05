using Consultorio.Model;
using Consultorio.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.DB.Mappings
{
    internal class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {

            builder.Property(c => c.DataConsulta)
            .HasConversion<DateOnlyConverter>()
            .IsRequired();
        }
    }
}
