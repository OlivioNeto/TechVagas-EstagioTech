
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Objects.Enums;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<TipoEstagioModel> TipoEstagio { get; set; }
        public DbSet<CursoModel> Curso { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumento { get; set; }
        public DbSet<DocumentoModel> Documento { get; set; }
        public DbSet<VagasModel> Vagas { get; set; }
        public DbSet<CargoModel> Cargos { get; set; }
        public DbSet<ConcedenteModel> Concedentes { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<DocumentoVersaoModel> DocumentoVersao { get; set; }
        public DbSet<DocumentoNecessarioModel> DocumentoNecessario { get; set; }
        public DbSet<InstituicaoEnsinoModel> InstituicaoEnsino { get; set; }
        public DbSet<ApontamentoModel> Apontamento { get; set; }
        public DbSet<CoordenadorEstagioModel> CoordenadorEstagio { get; set; }
        public DbSet<SupervisorEstagioModel> SupervisorEstagio { get; set; }
        public DbSet<ContratoEstagioModel> ContratoEstagio { get; set; }
        public DbSet<MatriculaModel> Matricula { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<SessaoModel> Sessao { get; set; }
        public DbSet<LoginModel> Login { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LIMITANDO O MÁXIMO DE CARACTERES

            //Alunos
            modelBuilder.Entity<AlunoModel>().HasKey(x => x.AlunoId);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Nome).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Idade).IsRequired();
            modelBuilder.Entity<AlunoModel>().Property(x => x.Rg).IsRequired().HasMaxLength(12);
            modelBuilder.Entity<AlunoModel>().Property(x => x.StatusAluno).IsRequired();
            modelBuilder.Entity<AlunoModel>().Property(x => x.NumeroMatricula).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AlunoModel>().Property(x => x.AreaInteresse).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Habilidades).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Experiencias).IsRequired().HasMaxLength(350);
            modelBuilder.Entity<AlunoModel>().Property(x => x.DisponibilidadeHorario).IsRequired().HasMaxLength(35);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Curriculo).IsRequired();
            modelBuilder.Entity<AlunoModel>().Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Cidade).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AlunoModel>().Property(x => x.DataNascimento).IsRequired();
            modelBuilder.Entity<AlunoModel>().Property(x => x.NivelEscolaridade).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Telefone).IsRequired().HasMaxLength(14);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Endereco).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Genero).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Bairro).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<AlunoModel>().Property(x => x.Cep).IsRequired().HasMaxLength(9);

            //Apontamento
            modelBuilder.Entity<ApontamentoModel>().HasKey(x => x.idApontamento);
            modelBuilder.Entity<ApontamentoModel>().Property(x => x.descricaoApontamento).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ApontamentoModel>().Property(x => x.dataApontamento).IsRequired();
            modelBuilder.Entity<ApontamentoModel>().HasOne(b => b.CoordenadorEstagio).WithMany().HasForeignKey(b => b.idCoordenadorEstagio);

            //Cargo
            modelBuilder.Entity<CargoModel>().HasKey(x => x.CargoId);
            modelBuilder.Entity<CargoModel>().Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<CargoModel>().Property(x => x.Tipo).IsRequired().HasMaxLength(50);

            //Coordenador Estágio
            modelBuilder.Entity<CoordenadorEstagioModel>().HasKey(x => x.idCoordenadorEstagio);
            modelBuilder.Entity<CoordenadorEstagioModel>().Property(x => x.dataCadastro).IsRequired();
            modelBuilder.Entity<CoordenadorEstagioModel>().Property(x => x.nomeCoordenador).IsRequired();
            modelBuilder.Entity<CoordenadorEstagioModel>().Property(x => x.StatusCoordenadorEstagio).IsRequired();

            //Contrato Estagio 
            modelBuilder.Entity<ContratoEstagioModel>().HasKey(x => x.idContratoEstagio);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.statusContratoEstagio).IsRequired();
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.notaFinal).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.situacao).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.horarioEntrada).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.horarioSaida).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.dataInicio).IsRequired();
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.dataFim).IsRequired();
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.salario).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.cargaSemanal).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().Property(x => x.cargaTotal).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ContratoEstagioModel>().HasOne(x => x.SupervisorEstagio).WithMany().HasForeignKey(x => x.idSupervisorEstagio);

            //Concedente
            modelBuilder.Entity<ConcedenteModel>().HasKey(x => x.concedenteId);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.RazaoSocial).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.ResponsavelEstagio).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Cnpj).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Localidade).IsRequired().HasMaxLength(50);

            //Curso
            modelBuilder.Entity<CursoModel>().HasKey(x => x.cursoid);
            modelBuilder.Entity<CursoModel>().Property(x => x.nomeCurso).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<CursoModel>().Property(x => x.turnoCurso).IsRequired().HasMaxLength(100);

            //Documento
            modelBuilder.Entity<DocumentoModel>().HasKey(x => x.idDocumento);
            modelBuilder.Entity<DocumentoModel>().HasMany(d => d.DocumentoVersoes).WithOne(v => v.Documento).HasForeignKey(v => v.DocumentoId);
            modelBuilder.Entity<DocumentoModel>().Property(x => x.descricaoDocumento).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoModel>().Property(x => x.situacaoDocumento).IsRequired().HasMaxLength(200);

            //Documento versão
            modelBuilder.Entity<DocumentoVersaoModel>().HasKey(x => x.idDocumentoVersao);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Comentario).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Anexo).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Data).IsRequired();
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Situacao).IsRequired().HasMaxLength(200);

            //Documento necessário
            modelBuilder.Entity<DocumentoNecessarioModel>().HasKey(x => x.idDocumentoNecessario);
            modelBuilder.Entity<DocumentoNecessarioModel>().HasOne(b => b.TipoDocumento).WithMany().HasForeignKey(b => b.idTipoDocumento);
            modelBuilder.Entity<DocumentoNecessarioModel>().HasOne(b => b.TipoEstagio).WithMany().HasForeignKey(b => b.idTipoEstagio);

            //Supervisor Estagio
            modelBuilder.Entity<SupervisorEstagioModel>().HasKey(x => x.idSupervisor);
            modelBuilder.Entity<SupervisorEstagioModel>().Property(x => x.nomeSupervisor).IsRequired();
            modelBuilder.Entity<SupervisorEstagioModel>().Property(x => x.statusSupervisor).IsRequired();
            modelBuilder.Entity<SupervisorEstagioModel>().HasOne(b => b.Concedente).WithMany().HasForeignKey(b => b.concedenteId);
            
            //TipoDocumento
            modelBuilder.Entity<TipoDocumentoModel>().HasKey(x => x.idTipoDocumento);
            modelBuilder.Entity<TipoDocumentoModel>().Property(x => x.descricaoTipoDocumento).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<TipoDocumentoModel>().Property(x => x.Status).IsRequired();

            //TipoEstagio
            modelBuilder.Entity<TipoEstagioModel>().HasKey(x => x.idTipoEstagio);
            modelBuilder.Entity<TipoEstagioModel>().Property(x => x.descricaoTipoEstagio).IsRequired().HasMaxLength(200);

            //Vagas
            modelBuilder.Entity<VagasModel>().HasKey(x => x.VagasId);
            modelBuilder.Entity<VagasModel>().Property(x => x.Quantidade).IsRequired();
            modelBuilder.Entity<VagasModel>().Property(x => x.DataPublicacao).IsRequired();
            modelBuilder.Entity<VagasModel>().Property(x => x.DataLimite).IsRequired();
            modelBuilder.Entity<VagasModel>().Property(x => x.Localidade).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<VagasModel>().Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<VagasModel>().Property(x => x.Titulo).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<VagasModel>().Property(x => x.LocalidadeTrabalho).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<VagasModel>().Property(x => x.HorarioEntrada).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<VagasModel>().Property(x => x.HorarioSaida).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<VagasModel>().Property(x => x.TotalHorasSemanis).IsRequired().HasMaxLength(6);

            //Instituicao Ensino
            modelBuilder.Entity<InstituicaoEnsinoModel>().HasKey(x => x.idInstituicaoEnsino);
            modelBuilder.Entity<InstituicaoEnsinoModel>().Property(x => x.NomeInstituicao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<InstituicaoEnsinoModel>().Property(x => x.LocalInstituicao).IsRequired().HasMaxLength(120);
            modelBuilder.Entity<InstituicaoEnsinoModel>().Property(x => x.TelefoneInstituicao).IsRequired().HasMaxLength(17);

            //Matricula
            modelBuilder.Entity<MatriculaModel>().HasKey(x => x.MatriculaId);
            modelBuilder.Entity<MatriculaModel>().Property(x => x.NumeroMatricula).IsRequired().HasMaxLength(15);

            //SessaoModel
            modelBuilder.Entity<UsuarioModel>().HasKey(b => b.UsuarioId);
            modelBuilder.Entity<UsuarioModel>().Property(b => b.Nome).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.CpfCnpj).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.Email).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.Senha).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.UserType).IsRequired();

            //Login
            modelBuilder.Entity<LoginModel>().HasNoKey();

            //SessaoModel
            modelBuilder.Entity<SessaoModel>().HasKey(b => b.SessaoId);
            modelBuilder.Entity<SessaoModel>().Property(b => b.DataHoraInicio).IsRequired();
            modelBuilder.Entity<SessaoModel>().Property(b => b.DataHoraEncerramento);
            modelBuilder.Entity<SessaoModel>().Property(b => b.TokenSessao);
            modelBuilder.Entity<SessaoModel>().Property(b => b.StatusSessao).IsRequired();
            modelBuilder.Entity<SessaoModel>().Property(b => b.EmailPessoa);
            modelBuilder.Entity<SessaoModel>().Property(b => b.NivelAcesso);
            modelBuilder.Entity<SessaoModel>().HasOne(b => b.UsuarioModel).WithMany().HasForeignKey(b => b.UsuarioId);

            // Relacionamento: Usuario -> Sessao
            modelBuilder.Entity<UsuarioModel>().HasMany(p => p.Sessoes).WithOne(b => b.UsuarioModel).IsRequired().OnDelete(DeleteBehavior.Cascade);


            //Relacionamento: Vagas -> Cargo
            modelBuilder.Entity<VagasModel>()
                .HasOne(v => v.Cargo)
                .WithMany()
                .HasForeignKey(v => v.CargoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: Concedente -> Vagas
            modelBuilder.Entity<ConcedenteModel>()
                .HasMany(x => x.Vagas)
                .WithOne(y => y.Concedente)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relacionamento: Documento -> Documento Versão
            modelBuilder.Entity<DocumentoVersaoModel>().HasKey(x => x.idDocumentoVersao);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Situacao).IsRequired();

            //Relacionamento: CoordenadorEstagio -> Apontamento
            modelBuilder.Entity<ApontamentoModel>().HasKey(x => x.idApontamento);

            modelBuilder.Entity<UsuarioModel>().HasData(
               new UsuarioModel { UsuarioId = 1, Nome = "Admin", Email = "techvdev@development.com", Senha = "123456", CpfCnpj = "000.000.000-00", UserType = UserType.Administrador }
           );

            //Relacionamento: CoordenadorEstagio -> ContratoEstagio
            modelBuilder.Entity<ContratoEstagioModel>().HasKey(x => x.idContratoEstagio);

            //Relacionamento: SupervisorEstagio -> ContratoEstagio
            modelBuilder.Entity<ContratoEstagioModel>().HasKey(x => x.idContratoEstagio);

            //Relacionamento: TipoEstagio -> ContratoEstagio
            modelBuilder.Entity<ContratoEstagioModel>().HasKey(x => x.idContratoEstagio);

            //Relacionamento: Aluno -> Matricula
            modelBuilder.Entity<MatriculaModel>().HasKey(x => x.MatriculaId);

            //Relacionamento: Curso -> Matricula
            modelBuilder.Entity<MatriculaModel>().HasKey(x => x.MatriculaId);


            //DEIXANDO DADOS PRÉ-CADASTRADOS

            //Tipo Estagio
            modelBuilder.Entity<TipoEstagioModel>().HasData(
                new TipoEstagioModel { idTipoEstagio = 1, descricaoTipoEstagio = "Equivalência" },
                new TipoEstagioModel { idTipoEstagio = 2, descricaoTipoEstagio = "Normal" }
            );

            //Tipo Documento
            modelBuilder.Entity<TipoDocumentoModel>().HasData(
                new TipoDocumentoModel { idTipoDocumento = 1, descricaoTipoDocumento = "Contrato Social", Status = true },
                new TipoDocumentoModel { idTipoDocumento = 2, descricaoTipoDocumento = "CLT", Status = true },
                new TipoDocumentoModel { idTipoDocumento = 3, descricaoTipoDocumento = "Especificação", Status = true },
                new TipoDocumentoModel { idTipoDocumento = 4, descricaoTipoDocumento = "Seguro de assistentes pessoais", Status = true }
            );

            //Documento Necessário
            modelBuilder.Entity<DocumentoNecessarioModel>().HasData(
                new DocumentoNecessarioModel { idDocumentoNecessario = 1, idTipoEstagio = 1, idTipoDocumento = 1 },
                new DocumentoNecessarioModel { idDocumentoNecessario = 2, idTipoEstagio = 1, idTipoDocumento = 2 },
                new DocumentoNecessarioModel { idDocumentoNecessario = 3, idTipoEstagio = 1, idTipoDocumento = 3 },
                new DocumentoNecessarioModel { idDocumentoNecessario = 4, idTipoEstagio = 1, idTipoDocumento = 4 },
                new DocumentoNecessarioModel { idDocumentoNecessario = 5, idTipoEstagio = 2, idTipoDocumento = 4 }
            );
        }
    }
}
