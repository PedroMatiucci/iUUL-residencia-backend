using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class mudancanome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteForeignKey",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PacienteForeignKey",
                table: "Consultas",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "ConsultaId",
                table: "Consultas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteForeignKey",
                table: "Consultas",
                newName: "IX_Consultas_PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacientes",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Consultas",
                newName: "PacienteForeignKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Consultas",
                newName: "ConsultaId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                newName: "IX_Consultas_PacienteForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteForeignKey",
                table: "Consultas",
                column: "PacienteForeignKey",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
