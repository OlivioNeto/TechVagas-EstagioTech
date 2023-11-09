using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TechVagas_EstagioTech.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concedente",
                columns: table => new
                {
                    concedenteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razaosocial = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    responsavelestagio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    localidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concedente", x => x.concedenteid);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    idCurso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomeCurso = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.idCurso);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    idDocumento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricaoDocumento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    documento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    situacaoDocumento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.idDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    idTipoDocumento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricaoTipoDocumento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.idTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstagio",
                columns: table => new
                {
                    idTipoEstagio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricaoTipoEstagio = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstagio", x => x.idTipoEstagio);
                });

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
                    totalhorassemanais = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    concedenteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.vagasid);
                    table.ForeignKey(
                        name: "FK_vagas_concedente_concedenteId",
                        column: x => x.concedenteId,
                        principalTable: "concedente",
                        principalColumn: "concedenteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    cargoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vagasid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.cargoid);
                    table.ForeignKey(
                        name: "FK_cargo_vagas_vagasid",
                        column: x => x.vagasid,
                        principalTable: "vagas",
                        principalColumn: "vagasid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargo_vagasid",
                table: "cargo",
                column: "vagasid");

            migrationBuilder.CreateIndex(
                name: "IX_vagas_concedenteId",
                table: "vagas",
                column: "concedenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "TipoEstagio");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.DropTable(
                name: "concedente");
        }
    }
}
