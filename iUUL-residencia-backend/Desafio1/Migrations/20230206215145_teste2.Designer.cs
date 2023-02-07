﻿// <auto-generated />
using System;
using Consultorio.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Consultorio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230206215145_teste2")]
    partial class teste2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Consultorio.Model.Consulta", b =>
                {
                    b.Property<int>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultaId"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraFinal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInicial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("ConsultaId");

                    b.HasIndex("PacienteId")
                        .IsUnique();

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Consultorio.Model.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Consultorio.Model.Consulta", b =>
                {
                    b.HasOne("Consultorio.Model.Paciente", "Paciente")
                        .WithOne("Consulta")
                        .HasForeignKey("Consultorio.Model.Consulta", "PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Consultorio.Model.Paciente", b =>
                {
                    b.Navigation("Consulta")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
