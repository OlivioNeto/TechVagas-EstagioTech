using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    AlunoModelAlunoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.alunoid);
                    table.ForeignKey(
                        name: "FK_aluno_aluno_AlunoModelAlunoId",
                        column: x => x.AlunoModelAlunoId,
                        principalTable: "aluno",
                        principalColumn: "alunoid");
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    cargoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.cargoid);
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
                    datacadastro = table.Column<DateOnly>(type: "date", nullable: false),
                    nomecoordenador = table.Column<string>(type: "text", nullable: false),
                    statuscoordenadorestagio = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coordenadorestagio", x => x.coordenadorestagioid);
                });

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    cursoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomecurso = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    turnocurso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.cursoid);
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
                name: "login",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tipodocumento",
                columns: table => new
                {
                    tipodocumentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    statustipodocumento = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "usuario",
                columns: table => new
                {
                    usuarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cpfcnpjpessoa = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    usertype = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioid);
                });

            migrationBuilder.CreateTable(
                name: "supervisorestagio",
                columns: table => new
                {
                    supervisorid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomesupervisor = table.Column<string>(type: "text", nullable: false),
                    statussupervisorestagio = table.Column<bool>(type: "boolean", nullable: false),
                    concedenteid = table.Column<int>(type: "integer", nullable: false),
                    ConcedenteModelconcedenteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supervisorestagio", x => x.supervisorid);
                    table.ForeignKey(
                        name: "FK_supervisorestagio_concedente_ConcedenteModelconcedenteId",
                        column: x => x.ConcedenteModelconcedenteId,
                        principalTable: "concedente",
                        principalColumn: "concedenteid");
                    table.ForeignKey(
                        name: "FK_supervisorestagio_concedente_concedenteid",
                        column: x => x.concedenteid,
                        principalTable: "concedente",
                        principalColumn: "concedenteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    vagasid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<string>(type: "text", nullable: false),
                    datapublicacao = table.Column<DateOnly>(type: "date", nullable: false),
                    datalimite = table.Column<DateOnly>(type: "date", nullable: false),
                    localidade = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    descricao = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    titulo = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    localidadetrabalho = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horarioentrada = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horariosaida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    totalhorassemanais = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    concedenteId = table.Column<int>(type: "integer", nullable: false),
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.vagasid);
                    table.ForeignKey(
                        name: "FK_vagas_cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "cargo",
                        principalColumn: "cargoid",
                        onDelete: ReferentialAction.Restrict);
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
                    dataApontamento = table.Column<DateOnly>(type: "date", nullable: false),
                    coordenadorestagioid = table.Column<int>(type: "integer", nullable: false),
                    CoordenadorEstagioModelidCoordenadorEstagio = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apontamento", x => x.apontamentoid);
                    table.ForeignKey(
                        name: "FK_apontamento_coordenadorestagio_CoordenadorEstagioModelidCoo~",
                        column: x => x.CoordenadorEstagioModelidCoordenadorEstagio,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid");
                    table.ForeignKey(
                        name: "FK_apontamento_coordenadorestagio_coordenadorestagioid",
                        column: x => x.coordenadorestagioid,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    matriculaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numeromatricula = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AlunosAlunoId = table.Column<int>(type: "integer", nullable: true),
                    alunoid = table.Column<int>(type: "integer", nullable: false),
                    cursoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.matriculaid);
                    table.ForeignKey(
                        name: "FK_matricula_aluno_AlunosAlunoId",
                        column: x => x.AlunosAlunoId,
                        principalTable: "aluno",
                        principalColumn: "alunoid");
                    table.ForeignKey(
                        name: "FK_matricula_curso_cursoid",
                        column: x => x.cursoid,
                        principalTable: "curso",
                        principalColumn: "cursoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    documentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    situacao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipodocumentoid = table.Column<int>(type: "integer", nullable: false),
                    coordenadorestagioid = table.Column<int>(type: "integer", nullable: false),
                    CoordenadorEstagioModelidCoordenadorEstagio = table.Column<int>(type: "integer", nullable: true),
                    TipoDocumentoModelidTipoDocumento = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.documentoid);
                    table.ForeignKey(
                        name: "FK_documento_coordenadorestagio_CoordenadorEstagioModelidCoord~",
                        column: x => x.CoordenadorEstagioModelidCoordenadorEstagio,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid");
                    table.ForeignKey(
                        name: "FK_documento_coordenadorestagio_coordenadorestagioid",
                        column: x => x.coordenadorestagioid,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_tipodocumento_TipoDocumentoModelidTipoDocumento",
                        column: x => x.TipoDocumentoModelidTipoDocumento,
                        principalTable: "tipodocumento",
                        principalColumn: "tipodocumentoid");
                    table.ForeignKey(
                        name: "FK_documento_tipodocumento_tipodocumentoid",
                        column: x => x.tipodocumentoid,
                        principalTable: "tipodocumento",
                        principalColumn: "tipodocumentoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documentonecessario",
                columns: table => new
                {
                    documentonecessarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipodocumentoid = table.Column<int>(type: "integer", nullable: false),
                    tipoestagioid = table.Column<int>(type: "integer", nullable: false),
                    TipoDocumentoModelidTipoDocumento = table.Column<int>(type: "integer", nullable: true),
                    TipoEstagioModelidTipoEstagio = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentonecessario", x => x.documentonecessarioid);
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipodocumento_TipoDocumentoModelidTipoD~",
                        column: x => x.TipoDocumentoModelidTipoDocumento,
                        principalTable: "tipodocumento",
                        principalColumn: "tipodocumentoid");
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipodocumento_tipodocumentoid",
                        column: x => x.tipodocumentoid,
                        principalTable: "tipodocumento",
                        principalColumn: "tipodocumentoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipoestagio_TipoEstagioModelidTipoEstag~",
                        column: x => x.TipoEstagioModelidTipoEstagio,
                        principalTable: "tipoestagio",
                        principalColumn: "tipoestagioid");
                    table.ForeignKey(
                        name: "FK_documentonecessario_tipoestagio_tipoestagioid",
                        column: x => x.tipoestagioid,
                        principalTable: "tipoestagio",
                        principalColumn: "tipoestagioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sessao",
                columns: table => new
                {
                    idsessao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datahoraabertura = table.Column<string>(type: "text", nullable: false),
                    datahorafechamento = table.Column<string>(type: "text", nullable: true),
                    tokensessao = table.Column<string>(type: "text", nullable: false),
                    statussessao = table.Column<bool>(type: "boolean", nullable: false),
                    emailpessoa = table.Column<string>(type: "text", nullable: false),
                    nivelacesso = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessao", x => x.idsessao);
                    table.ForeignKey(
                        name: "FK_sessao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contratoestagio",
                columns: table => new
                {
                    ContratoEstagioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusdoContratoEstagio = table.Column<bool>(name: "Status do ContratoEstagio", type: "boolean", nullable: false),
                    notafinal = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    situacao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    HorariodeEntrada = table.Column<string>(name: "Horario de Entrada", type: "character varying(150)", maxLength: 150, nullable: false),
                    HorariodeSaida = table.Column<string>(name: "Horario de Saida", type: "character varying(150)", maxLength: 150, nullable: false),
                    datainicio = table.Column<DateOnly>(type: "date", nullable: false),
                    datafim = table.Column<DateOnly>(type: "date", nullable: false),
                    salario = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cargasemanal = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cargatotal = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CoordenadorEstagioidCoordenadorEstagio = table.Column<int>(type: "integer", nullable: true),
                    coordenadorestagioid = table.Column<int>(type: "integer", nullable: false),
                    supervisorestagioid = table.Column<int>(type: "integer", nullable: false),
                    TipoEstagioidTipoEstagio = table.Column<int>(type: "integer", nullable: true),
                    tipoestagioid = table.Column<int>(type: "integer", nullable: false),
                    SupervisorEstagioModelidSupervisor = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratoestagio", x => x.ContratoEstagioid);
                    table.ForeignKey(
                        name: "FK_contratoestagio_coordenadorestagio_CoordenadorEstagioidCoor~",
                        column: x => x.CoordenadorEstagioidCoordenadorEstagio,
                        principalTable: "coordenadorestagio",
                        principalColumn: "coordenadorestagioid");
                    table.ForeignKey(
                        name: "FK_contratoestagio_supervisorestagio_SupervisorEstagioModelidS~",
                        column: x => x.SupervisorEstagioModelidSupervisor,
                        principalTable: "supervisorestagio",
                        principalColumn: "supervisorid");
                    table.ForeignKey(
                        name: "FK_contratoestagio_supervisorestagio_supervisorestagioid",
                        column: x => x.supervisorestagioid,
                        principalTable: "supervisorestagio",
                        principalColumn: "supervisorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contratoestagio_tipoestagio_TipoEstagioidTipoEstagio",
                        column: x => x.TipoEstagioidTipoEstagio,
                        principalTable: "tipoestagio",
                        principalColumn: "tipoestagioid");
                });

            migrationBuilder.CreateTable(
                name: "documentoversao",
                columns: table => new
                {
                    documentoversaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comentario = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    anexo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
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

            migrationBuilder.InsertData(
                table: "concedente",
                columns: new[] { "concedenteid", "cnpj", "localidade", "razaosocial", "responsavelestagio" },
                values: new object[,]
                {
                    { 1, "02433981000196", "Jales - SP", "PRECISAO SISTEMAS LTDA", "Ailton Reynaldo" },
                    { 2, "07468363000103", "Jales - SP", "SISTEMASBR SOLUCOES EM TECNOLOGIA LTDA", "Fernando Nogarini" },
                    { 3, "03997115000190", "Jales - SP", "SISCOMP TECNOLOGIA EM SISTEMAS LTDA", "Silvio" },
                    { 4, "00000000000000", "Jales - SP", "Fatec Jales", "Evanivaldo Castro" }
                });

            migrationBuilder.InsertData(
                table: "coordenadorestagio",
                columns: new[] { "coordenadorestagioid", "statuscoordenadorestagio", "datacadastro", "nomecoordenador" },
                values: new object[,]
                {
                    { 1, true, new DateOnly(2024, 6, 13), "Jorge Gregório" },
                    { 2, true, new DateOnly(2024, 6, 13), "Tiago Ribeiro" },
                    { 3, true, new DateOnly(2024, 6, 13), "Emerson Mouco" },
                    { 4, true, new DateOnly(2024, 6, 13), "Vitor Boldrin" },
                    { 5, true, new DateOnly(2024, 6, 13), "Adriana de Souza" },
                    { 6, true, new DateOnly(2024, 6, 13), "Gláucia Alvarez" },
                    { 7, true, new DateOnly(2024, 6, 13), "Fellipe Ricardo" }
                });

            migrationBuilder.InsertData(
                table: "instituicaoensino",
                columns: new[] { "id", "local", "nomeinstituicao", "telefone" },
                values: new object[,]
                {
                    { 1, "Jales - SP", "Fatec Professor José Camargo", "17996762867" },
                    { 2, "Jales - SP", "UniJales", "17996651620" },
                    { 3, "Fernandópolis - SP", "Fundação Educacional de Fernandópolis", "17981840110" },
                    { 4, "Santa Fé do Sul - SP", "UniFunec", "17996324602" }
                });

            migrationBuilder.InsertData(
                table: "tipodocumento",
                columns: new[] { "tipodocumentoid", "statustipodocumento", "descricao" },
                values: new object[,]
                {
                    { 1, true, "Contrato Social" },
                    { 2, true, "CLT" },
                    { 3, true, "Especificação" },
                    { 4, true, "Seguro de assistentes pessoais" }
                });

            migrationBuilder.InsertData(
                table: "tipoestagio",
                columns: new[] { "tipoestagioid", "descricao" },
                values: new object[,]
                {
                    { 1, "Equivalência" },
                    { 2, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "usuarioid", "cpfcnpjpessoa", "email", "nome", "senha", "usertype" },
                values: new object[] { 1, "000.000.000-00", "techvdev@development.com", "Admin", "123456", 1 });

            migrationBuilder.InsertData(
                table: "documentonecessario",
                columns: new[] { "documentonecessarioid", "TipoDocumentoModelidTipoDocumento", "TipoEstagioModelidTipoEstagio", "tipodocumentoid", "tipoestagioid" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1 },
                    { 2, null, null, 2, 1 },
                    { 3, null, null, 3, 1 },
                    { 4, null, null, 4, 1 },
                    { 5, null, null, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "supervisorestagio",
                columns: new[] { "supervisorid", "ConcedenteModelconcedenteId", "statussupervisorestagio", "concedenteid", "nomesupervisor" },
                values: new object[,]
                {
                    { 1, null, true, 4, "Jorge Gregório" },
                    { 2, null, true, 4, "Tiago Ribeiro" },
                    { 3, null, true, 4, "Luciana Matsunaga" },
                    { 4, null, true, 4, "Fellipe Ricardo" },
                    { 5, null, true, 1, "Vivian Basilio" },
                    { 6, null, true, 1, "Augusto Formentão" },
                    { 7, null, true, 2, "Lidia de Haro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_AlunoModelAlunoId",
                table: "aluno",
                column: "AlunoModelAlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_apontamento_coordenadorestagioid",
                table: "apontamento",
                column: "coordenadorestagioid");

            migrationBuilder.CreateIndex(
                name: "IX_apontamento_CoordenadorEstagioModelidCoordenadorEstagio",
                table: "apontamento",
                column: "CoordenadorEstagioModelidCoordenadorEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_contratoestagio_CoordenadorEstagioidCoordenadorEstagio",
                table: "contratoestagio",
                column: "CoordenadorEstagioidCoordenadorEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_contratoestagio_supervisorestagioid",
                table: "contratoestagio",
                column: "supervisorestagioid");

            migrationBuilder.CreateIndex(
                name: "IX_contratoestagio_SupervisorEstagioModelidSupervisor",
                table: "contratoestagio",
                column: "SupervisorEstagioModelidSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_contratoestagio_TipoEstagioidTipoEstagio",
                table: "contratoestagio",
                column: "TipoEstagioidTipoEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_documento_coordenadorestagioid",
                table: "documento",
                column: "coordenadorestagioid");

            migrationBuilder.CreateIndex(
                name: "IX_documento_CoordenadorEstagioModelidCoordenadorEstagio",
                table: "documento",
                column: "CoordenadorEstagioModelidCoordenadorEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_documento_tipodocumentoid",
                table: "documento",
                column: "tipodocumentoid");

            migrationBuilder.CreateIndex(
                name: "IX_documento_TipoDocumentoModelidTipoDocumento",
                table: "documento",
                column: "TipoDocumentoModelidTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_tipodocumentoid",
                table: "documentonecessario",
                column: "tipodocumentoid");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_TipoDocumentoModelidTipoDocumento",
                table: "documentonecessario",
                column: "TipoDocumentoModelidTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_tipoestagioid",
                table: "documentonecessario",
                column: "tipoestagioid");

            migrationBuilder.CreateIndex(
                name: "IX_documentonecessario_TipoEstagioModelidTipoEstagio",
                table: "documentonecessario",
                column: "TipoEstagioModelidTipoEstagio");

            migrationBuilder.CreateIndex(
                name: "IX_documentoversao_documentoid",
                table: "documentoversao",
                column: "documentoid");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_AlunosAlunoId",
                table: "matricula",
                column: "AlunosAlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_cursoid",
                table: "matricula",
                column: "cursoid");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_UsuarioId",
                table: "sessao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_supervisorestagio_concedenteid",
                table: "supervisorestagio",
                column: "concedenteid");

            migrationBuilder.CreateIndex(
                name: "IX_supervisorestagio_ConcedenteModelconcedenteId",
                table: "supervisorestagio",
                column: "ConcedenteModelconcedenteId");

            migrationBuilder.CreateIndex(
                name: "IX_vagas_CargoId",
                table: "vagas",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_vagas_concedenteId",
                table: "vagas",
                column: "concedenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apontamento");

            migrationBuilder.DropTable(
                name: "contratoestagio");

            migrationBuilder.DropTable(
                name: "documentonecessario");

            migrationBuilder.DropTable(
                name: "documentoversao");

            migrationBuilder.DropTable(
                name: "instituicaoensino");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "sessao");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.DropTable(
                name: "supervisorestagio");

            migrationBuilder.DropTable(
                name: "tipoestagio");

            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "concedente");

            migrationBuilder.DropTable(
                name: "coordenadorestagio");

            migrationBuilder.DropTable(
                name: "tipodocumento");
        }
    }
}
