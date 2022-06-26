using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initialMagration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "Nvarchar", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "Nvarchar", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetExercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Repeticao = table.Column<int>(type: "INTEGER", nullable: false),
                    Series = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetExercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetPlanos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetPlanos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instrutor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "Nvarchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrutor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetTreino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ExercicioId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstrutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetTreino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSetTreino_DbSetExercicio_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "DbSetExercicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DbSetTreino_instrutor_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "instrutor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DbSetMatricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Mensalidadeid = table.Column<int>(type: "INTEGER", nullable: true),
                    TreinoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetMatricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSetMatricula_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DbSetMatricula_DbSetPlanos_Mensalidadeid",
                        column: x => x.Mensalidadeid,
                        principalTable: "DbSetPlanos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DbSetMatricula_DbSetTreino_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "DbSetTreino",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbSetMatricula_AlunoId",
                table: "DbSetMatricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSetMatricula_Mensalidadeid",
                table: "DbSetMatricula",
                column: "Mensalidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_DbSetMatricula_TreinoId",
                table: "DbSetMatricula",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSetTreino_ExercicioId",
                table: "DbSetTreino",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSetTreino_InstrutorId",
                table: "DbSetTreino",
                column: "InstrutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSetMatricula");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "DbSetPlanos");

            migrationBuilder.DropTable(
                name: "DbSetTreino");

            migrationBuilder.DropTable(
                name: "DbSetExercicio");

            migrationBuilder.DropTable(
                name: "instrutor");
        }
    }
}
