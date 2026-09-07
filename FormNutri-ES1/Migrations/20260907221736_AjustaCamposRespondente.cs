using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormNutri_ES1.Migrations
{
    /// <inheritdoc />
    public partial class AjustaCamposRespondente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Respondente_Dependentes",
                table: "RegistroAvaliacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respondente_Dependentes",
                table: "RegistroAvaliacoes");
        }
    }
}
