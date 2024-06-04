using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechVagas_EstagioTech.Migrations
{
    /// <inheritdoc />
    public partial class teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "quantidade",
                table: "vagas",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "vagas",
                type: "character varying(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "vagas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "vagas",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(800)",
                oldMaxLength: 800);
        }
    }
}
