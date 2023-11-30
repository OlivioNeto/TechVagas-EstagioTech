using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TipoEstagioModel> TipoEstagio { get; set; }
        public DbSet<CursoModel> Curso { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumento { get; set; }
        public DbSet<DocumentoModel> Documento { get; set; }
        public DbSet<VagasModel> Vagas { get; set; }
        public DbSet<CargoModel> Cargos { get; set; }
		public DbSet<ConcedenteModel> Concedentes { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<DocumentoVersaoModel> DocumentoVersao { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TipoUsuarioModel> tipoUsuario { get; set; }
        public DbSet<LoginModel> login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Builder: TipoUsuario
            modelBuilder.Entity<TipoUsuarioModel>().HasKey(b => b.tipoUsuarioId);
            modelBuilder.Entity<TipoUsuarioModel>().Property(b => b.NivelAcesso).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<TipoUsuarioModel>().Property(b => b.NomeTipoUsuario).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<TipoUsuarioModel>().Property(b => b.DescricaoTipoUsuario).HasMaxLength(300).IsRequired();

            //Cargo
            modelBuilder.Entity<CargoModel>().HasKey(x => x.CargoId);
            modelBuilder.Entity<CargoModel>().Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<CargoModel>().Property(x => x.Tipo).IsRequired().HasMaxLength(50);

            //Concedente
            modelBuilder.Entity<ConcedenteModel>().HasKey(x => x.concedenteId);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.RazaoSocial).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.ResponsavelEstagio).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Cnpj).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Localidade).IsRequired().HasMaxLength(50);

            // Builder: Usuario 
            modelBuilder.Entity<UsuarioModel>().HasKey(b => b.usuarioId);
            modelBuilder.Entity<UsuarioModel>().Property(b => b.NomeUsuario).HasMaxLength(70).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.EmailUsuario).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.SenhaUsuario).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(b => b.StatusUsuario).HasMaxLength(19).IsRequired();

            // Relacionamento: TipoUsuario -> Usuario
            modelBuilder.Entity<TipoUsuarioModel>().HasMany(p => p.Usuarios).WithOne(b => b.TipoUsuario).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Curso
            modelBuilder.Entity<CursoModel>().HasKey(x => x.idCurso);
			modelBuilder.Entity<CursoModel>().Property(x => x.nomeCurso).IsRequired().HasMaxLength(200);

			//Documento
			modelBuilder.Entity<DocumentoModel>().HasKey(x => x.DocumentoId);
            modelBuilder.Entity<DocumentoModel>().HasMany(d => d.DocumentoVersoes).WithOne(v => v.Documento).HasForeignKey(v => v.DocumentoId);
            modelBuilder.Entity<DocumentoModel>().Property(x => x.descricaoDocumento).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<DocumentoModel>().Property(x => x.situacaoDocumento).IsRequired().HasMaxLength(200);

            //Documento versão
            modelBuilder.Entity<DocumentoVersaoModel>().HasKey(x => x.DocumentoVersaoId);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Comentario).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Anexo).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Data).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x => x.Situacao).IsRequired().HasMaxLength(200);

            //TipoDocumento
            modelBuilder.Entity<TipoDocumentoModel>().HasKey(x => x.idTipoDocumento);
			modelBuilder.Entity<TipoDocumentoModel>().Property(x => x.descricaoTipoDocumento).IsRequired().HasMaxLength(200);

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
			modelBuilder.Entity<VagasModel>().Property(x => x.TotalHorasSemanis).IsRequired().HasMaxLength(20);
			          
            //Relacionamento: Cargo -> Vagas
            modelBuilder.Entity<VagasModel>()
				.HasMany(c => c.Cargos)
				.WithOne(v => v.Vagas)
				.IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relacionamento: Concedente -> Vagas
            modelBuilder.Entity<ConcedenteModel>()
                .HasMany(x => x.Vagas)
                .WithOne(y => y.Concedente)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Relacionamento: Documento -> Documento Versão
            modelBuilder.Entity<DocumentoVersaoModel>().HasKey(x => x.DocumentoVersaoId);
            modelBuilder.Entity<DocumentoVersaoModel>().Property(x=> x.Situacao).IsRequired();

            //Iserções
            modelBuilder.Entity<TipoUsuarioModel>().HasData(
                new TipoUsuarioModel { tipoUsuarioId = 1, NomeTipoUsuario = "Desenvolvedor", NivelAcesso = "A", DescricaoTipoUsuario = "Pode efetuar todas as funcionalidades disponíveis. Voltado ao time de desenvolvimento." },
                new TipoUsuarioModel { tipoUsuarioId = 2, NomeTipoUsuario = "Admin", NivelAcesso = "A", DescricaoTipoUsuario = "Pode efetuar todas as funcionalidades disponíveis. ." },
                new TipoUsuarioModel { tipoUsuarioId = 3, NomeTipoUsuario = "Aluno", NivelAcesso = "C", DescricaoTipoUsuario = "Apenas vizualizar informações, porém dados sensíveis são mascarados." }
);

            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel { usuarioId = 1, NomeUsuario = "Dev", EmailUsuario = "devproduction@gmail.com", SenhaUsuario = "123456", StatusUsuario = true, IdTipoUsuario = 1 },
                new UsuarioModel { usuarioId = 2, NomeUsuario = "Admin", EmailUsuario = "admin@gmail.com", SenhaUsuario = "123456", StatusUsuario = true, IdTipoUsuario = 2 },
                new UsuarioModel { usuarioId = 3, NomeUsuario = "Aluno", EmailUsuario = "aluno@gmail.com", SenhaUsuario = "123456", StatusUsuario = true, IdTipoUsuario = 3 }
            );


        }
    }
}
