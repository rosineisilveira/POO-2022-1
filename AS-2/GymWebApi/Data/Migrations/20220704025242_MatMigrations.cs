using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MatMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Pagamento",
                table: "matricula");

            migrationBuilder.RenameColumn(
                name: "MensalidadeId",
                table: "matricula",
                newName: "PlanoId");

            migrationBuilder.RenameIndex(
                name: "IX_matricula_MensalidadeId",
                table: "matricula",
                newName: "IX_matricula_PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_PagamentoId",
                table: "matricula",
                column: "PagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Pagamento",
                table: "matricula",
                column: "PagamentoId",
                principalTable: "pagamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Pagamento",
                table: "matricula");

            migrationBuilder.DropIndex(
                name: "IX_matricula_PagamentoId",
                table: "matricula");

            migrationBuilder.RenameColumn(
                name: "PlanoId",
                table: "matricula",
                newName: "MensalidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_matricula_PlanoId",
                table: "matricula",
                newName: "IX_matricula_MensalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Pagamento",
                table: "matricula",
                column: "id",
                principalTable: "pagamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
