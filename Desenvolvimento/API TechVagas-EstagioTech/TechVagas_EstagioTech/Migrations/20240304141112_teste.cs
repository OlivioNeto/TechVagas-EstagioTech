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
                name: "aluno",
                columns: table => new
                {
                    alunoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    idade = table.Column<int>(type: "integer", nullable: false),
                    rg = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    statusaluno = table.Column<bool>(type: "boolean", nullable: false),
                    numeromatricula = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    areainteresse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    habilidades = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    experiencias = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    disponibilidadehorario = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    curriculo = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nivelescolaridade = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    telefone = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    genero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    bairro = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.alunoid);
                });

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
                name: "coordenadorestagio",
                columns: table => new
                {
                    coordenadorestagioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datacadastro = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    statuscoordenador = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coordenadorestagio", x => x.coordenadorestagioid);
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
                name: "documento",
                columns: table => new
                {
                    documentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    situacao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.documentoid);
                });

            migrationBuilder.CreateTable(
                name: "instituicaoensino",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomeinstituicao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    local = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    telefone = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicaoensino", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipodocumento",
                columns: table => new
                {
                    tipodocumentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodocumento", x => x.tipodocumentoid);
                });

            migrationBuilder.CreateTable(
                name: "tipoestagio",
                columns: table => new
                {
                    tipoestagioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoestagio", x => x.tipoestagioid);
                });

            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    vagasid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    datapublicacao = table.Column<DateOnly>(type: "date", nullable: false),
                    datalimite = table.Column<DateOnly>(type: "date", nullable: false),
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
                name: "apontamento",
                columns: table => new
                {
                    apontamentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricaoApontamento = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    dataApontamento = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CoordenadorEstagioidCoordenadorEstagio = table.Column<int>(type: "integer", nullable: true),
                    coordenadorestagioid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apontamento", x => x.apontamentoid);
                    table.ForeignKey(
                        name: "FK_apontamento_coordenadorestagio_CoordenadorEstagioidCoordena~",
                        column: x => x.CoordenadorEstagioidCoordenadorEstagio,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid");
                });

            migrationBuilder.CreateTable(
                name: "documentoversao",
                columns: table => new
                {
                    documentoversaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comentario = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    anexo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    situacao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    documentoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentoversao", x => x.documentoversaoid);
                    table.ForeignKey(
                        name: "FK_documentoversao_documento_documentoid",
                        column: x => x.documentoid,
                        principalTable: "documento",
                        principalColumn: "documentoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documentonecessario",
                columns: table => new
                {
                    documentonecessarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDocumentosidTipoDocumento = table.Column<int>(type: "integer", nullable: true),
                    tipodocumentoid = table.Column<int>(type: "integer", nullable: false),
                    TipoEstagiosidTipoEstagio = table.Column<int>(type: "integer", nullable: true),
                    tipoestagioid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentonecessario", x => x.documentonecessarioid);
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipodocumento_TipoDocumentosidTipoDocum~",
                        column: x => x.TipoDocumentosidTipoDocumento,
                        principalTable: "tipodocumento",
                        principalColumn: "tipodocumentoid");
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipoestagio_TipoEstagiosidTipoEstagio",
                        column: x => x.TipoEstagiosidTipoEstagio,
                        principalTable: "tipoestagio",
                        principalColumn: "tipoestagioid");
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
                name: "IX_apontamento_CoordenadorEstagioidCoordenadorEstagio",
                table: "apontamento",
                column: "CoordenadorEstagioidCoordenadorEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_cargo_vagasid",
                table: "cargo",
                column: "vagasid");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_TipoDocumentosidTipoDocumento",
                table: "documentonecessario",
                column: "TipoDocumentosidTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_TipoEstagiosidTipoEstagio",
                table: "documentonecessario",
                column: "TipoEstagiosidTipoEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_documentoversao_documentoid",
                table: "documentoversao",
                column: "documentoid");

            migrationBuilder.CreateIndex(
                name: "IX_vagas_concedenteId",
                table: "vagas",
                column: "concedenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "apontamento");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "documentonecessario");

            migrationBuilder.DropTable(
                name: "documentoversao");

            migrationBuilder.DropTable(
                name: "instituicaoensino");

            migrationBuilder.DropTable(
                name: "coordenadorestagio");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.DropTable(
                name: "tipodocumento");

            migrationBuilder.DropTable(
                name: "tipoestagio");

            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "concedente");
        }
    }
}
