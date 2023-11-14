using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechVagas_EstagioTech.Migrations
{
    /// <inheritdoc />
    public partial class funf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documento_documentoversao_DocumentoVersaoId",
                table: "documento");

            migrationBuilder.DropIndex(
                name: "IX_documento_DocumentoVersaoId",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "DocumentoVersaoId",
                table: "documento");

            migrationBuilder.CreateIndex(
                name: "IX_documentoversao_documentoid",
                table: "documentoversao",
                column: "documentoid");

            migrationBuilder.AddForeignKey(
                name: "FK_documentoversao_documento_documentoid",
                table: "documentoversao",
                column: "documentoid",
                principalTable: "documento",
                principalColumn: "documentoid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documentoversao_documento_documentoid",
                table: "documentoversao");

            migrationBuilder.DropIndex(
                name: "IX_documentoversao_documentoid",
                table: "documentoversao");

            migrationBuilder.AddColumn<int>(
                name: "DocumentoVersaoId",
                table: "documento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_documento_DocumentoVersaoId",
                table: "documento",
                column: "DocumentoVersaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_documento_documentoversao_DocumentoVersaoId",
                table: "documento",
                column: "DocumentoVersaoId",
                principalTable: "documentoversao",
                principalColumn: "documentoversaoid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
