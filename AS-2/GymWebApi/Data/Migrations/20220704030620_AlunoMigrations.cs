using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AlunoMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Mensalidade",
                table: "matricula");

            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "aluno",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_plano",
                table: "matricula",
                column: "PlanoId",
                principalTable: "plano",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_plano",
                table: "matricula");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "aluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Mensalidade",
                table: "matricula",
                column: "PlanoId",
                principalTable: "plano",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
