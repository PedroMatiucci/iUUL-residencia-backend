using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacientes",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Consultas",
                newName: "ConsultaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ConsultaId",
                table: "Consultas",
                newName: "Id");
        }
    }
}
