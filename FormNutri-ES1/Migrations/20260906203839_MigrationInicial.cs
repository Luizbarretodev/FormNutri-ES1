using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormNutri_ES1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroAvaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataColeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsentimentoLGPD = table.Column<bool>(type: "bit", nullable: false),
                    AplicadorId = table.Column<int>(type: "int", nullable: false),
                    Respondente_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_Idade = table.Column<int>(type: "int", nullable: false),
                    Respondente_Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_RacaCor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_Escolaridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_SituacaoEmprego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondente_RecebeBolsaFamilia = table.Column<bool>(type: "bit", nullable: false),
                    Respondente_Religiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcadorConsumo_RefeicoesRealizadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcadorConsumo_UsoTelaRefeicoes = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoFeijao = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoFrutas = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoVerduras = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoEmbutidos = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoBebidasAdocadas = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoMiojo = table.Column<int>(type: "int", nullable: false),
                    MarcadorConsumo_ConsumoDoces = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta1 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta2 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta3 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta4 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta5 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta6 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta7 = table.Column<int>(type: "int", nullable: false),
                    RespostaEbia_Pergunta8 = table.Column<int>(type: "int", nullable: false),
                    PontuacaoEbia = table.Column<int>(type: "int", nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroAvaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroAvaliacoes_Usuarios_AplicadorId",
                        column: x => x.AplicadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAvaliacoes_AplicadorId",
                table: "RegistroAvaliacoes",
                column: "AplicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroAvaliacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
