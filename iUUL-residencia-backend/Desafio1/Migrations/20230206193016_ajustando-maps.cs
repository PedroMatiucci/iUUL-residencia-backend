using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class ajustandomaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Consultas",
                newName: "PacienteForeignKey");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultaId",
                table: "Consultas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteForeignKey",
                table: "Consultas",
                column: "PacienteForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteForeignKey",
                table: "Consultas",
                column: "PacienteForeignKey",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteForeignKey",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteForeignKey",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteForeignKey",
                table: "Consultas",
                newName: "PacienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ConsultaId",
                table: "Consultas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
