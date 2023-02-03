using Consultorio.Model;
using Consultorio.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DB.Mappings
{
    internal class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
           {
            //builder.Property(c => c.ConsultaId);

            //builder.Property(c => c.CPF)
            //.IsRequired();

            builder.Property(c => c.DataConsulta)
            .HasConversion<DateOnlyConverter>()
            .IsRequired();



            //builder.Property(c => c.HoraInicial)
            //.IsRequired();

            //builder.Property(c => c.HoraFinal)
            //.IsRequired();



        }
    }
}
