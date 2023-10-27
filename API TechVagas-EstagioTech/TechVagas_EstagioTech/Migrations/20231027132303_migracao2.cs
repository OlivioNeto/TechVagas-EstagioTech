using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TechVagas_EstagioTech.Migrations
{
    /// <inheritdoc />
    public partial class migracao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    vagasid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    datapublicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datalimite = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    localidade = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    titulo = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    localidadetrabalho = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horarioentrada = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horariosaida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    totalhorassemanais = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.vagasid);
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    cargoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VagasModelVagasId = table.Column<int>(type: "integer", nullable: true),
                    VagasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.cargoid);
                    table.ForeignKey(
                        name: "FK_cargo_vagas_VagasModelVagasId",
                        column: x => x.VagasModelVagasId,
                        principalTable: "vagas",
                        principalColumn: "vagasid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargo_VagasModelVagasId",
                table: "cargo",
                column: "VagasModelVagasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });
        }
    }
}
