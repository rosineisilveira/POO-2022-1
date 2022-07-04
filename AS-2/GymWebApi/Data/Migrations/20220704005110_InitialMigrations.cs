using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercicio",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    repeticao = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    series = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercicio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instrutor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrutor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tipo = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plano",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    valor = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plano", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "treino",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    ExercicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    instrutor_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treino", x => x.id);
                    table.ForeignKey(
                        name: "FK_Treino_Instrutor",
                        column: x => x.instrutor_id,
                        principalTable: "instrutor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MensalidadeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PagamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno",
                        column: x => x.id,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_Mensalidade",
                        column: x => x.MensalidadeId,
                        principalTable: "plano",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_Pagamento",
                        column: x => x.id,
                        principalTable: "pagamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "treino_exercicio",
                columns: table => new
                {
                    exercicio_id = table.Column<int>(type: "INTEGER", nullable: false),
                    treino_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treino_exercicio", x => new { x.exercicio_id, x.treino_id });
                    table.ForeignKey(
                        name: "FK_treino_exercicio_exercicio_id",
                        column: x => x.exercicio_id,
                        principalTable: "exercicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_treino_exercicio_treino_id",
                        column: x => x.treino_id,
                        principalTable: "treino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matricula_treino",
                columns: table => new
                {
                    matricula_id = table.Column<int>(type: "INTEGER", nullable: false),
                    treino_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula_treino", x => new { x.matricula_id, x.treino_id });
                    table.ForeignKey(
                        name: "FK_matricula_treino_matricula_id",
                        column: x => x.matricula_id,
                        principalTable: "matricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matricula_treino_treino_id",
                        column: x => x.treino_id,
                        principalTable: "treino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "treino_matriculas",
                columns: table => new
                {
                    matricula_id = table.Column<int>(type: "INTEGER", nullable: false),
                    treino_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treino_matriculas", x => new { x.matricula_id, x.treino_id });
                    table.ForeignKey(
                        name: "FK_treino_matricula_matricula_id",
                        column: x => x.matricula_id,
                        principalTable: "matricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_treino_matricula_treino_id",
                        column: x => x.treino_id,
                        principalTable: "treino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_matricula_MensalidadeId",
                table: "matricula",
                column: "MensalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_treino_treino_id",
                table: "matricula_treino",
                column: "treino_id");

            migrationBuilder.CreateIndex(
                name: "IX_treino_instrutor_id",
                table: "treino",
                column: "instrutor_id");

            migrationBuilder.CreateIndex(
                name: "IX_treino_exercicio_treino_id",
                table: "treino_exercicio",
                column: "treino_id");

            migrationBuilder.CreateIndex(
                name: "IX_treino_matriculas_treino_id",
                table: "treino_matriculas",
                column: "treino_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matricula_treino");

            migrationBuilder.DropTable(
                name: "treino_exercicio");

            migrationBuilder.DropTable(
                name: "treino_matriculas");

            migrationBuilder.DropTable(
                name: "exercicio");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "treino");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "plano");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "instrutor");
        }
    }
}
