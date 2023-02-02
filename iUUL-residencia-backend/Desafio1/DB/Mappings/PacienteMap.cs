﻿using Consultorio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.DB.Mappings
{
    internal class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.Property(p => p.PacienteId);

            builder.Property(p => p.Nome)
            .IsRequired();

            builder.Property(p => p.CPF);

            builder.Property(p => p.DataNascimento)
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(p => p.Consulta);

            builder.HasKey(p => p.PacienteId);

        }
    }
}
