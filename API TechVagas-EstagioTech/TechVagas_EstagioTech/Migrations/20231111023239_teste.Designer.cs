﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TechVagas_EstagioTech.Data;

#nullable disable

namespace TechVagas_EstagioTech.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231111023239_teste")]
    partial class teste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.AlunoModel", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("alunoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("AreaInteresse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("areainteresse");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cidade");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("cpf");

                    b.Property<string>("Curriculo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("curriculo");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datanascimento");

                    b.Property<string>("DisponibilidadeHorario")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("disponibilidadehorario");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("endereco");

                    b.Property<string>("Experiencias")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)")
                        .HasColumnName("experiencias");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("genero");

                    b.Property<string>("Habilidades")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("habilidades");

                    b.Property<int>("Idade")
                        .HasColumnType("integer")
                        .HasColumnName("idade");

                    b.Property<string>("NivelEscolaridade")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("nivelescolaridade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("nome");

                    b.Property<string>("NumeroMatricula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("numeromatricula");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("rg");

                    b.Property<bool>("StatusAluno")
                        .HasColumnType("boolean")
                        .HasColumnName("statusaluno");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("telefone");

                    b.HasKey("AlunoId");

                    b.ToTable("aluno");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.CargoModel", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cargoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CargoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("descricao");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("tipo");

                    b.Property<int>("VagasId")
                        .HasColumnType("integer")
                        .HasColumnName("vagasid");

                    b.HasKey("CargoId");

                    b.HasIndex("VagasId");

                    b.ToTable("cargo");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.ConcedenteModel", b =>
                {
                    b.Property<int>("concedenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("concedenteid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("concedenteId"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("localidade");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("razaosocial");

                    b.Property<string>("ResponsavelEstagio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("responsavelestagio");

                    b.HasKey("concedenteId");

                    b.ToTable("concedente");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.CursoModel", b =>
                {
                    b.Property<int>("idCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idCurso"));

                    b.Property<string>("nomeCurso")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("idCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.DocumentoModel", b =>
                {
                    b.Property<int>("idDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idDocumento"));

                    b.Property<string>("descricaoDocumento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("situacaoDocumento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("idDocumento");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.TipoDocumentoModel", b =>
                {
                    b.Property<int>("idTipoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tipodocumentoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idTipoDocumento"));

                    b.Property<string>("descricaoTipoDocumento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("descricao");

                    b.HasKey("idTipoDocumento");

                    b.ToTable("tipodocumento");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.TipoEstagioModel", b =>
                {
                    b.Property<int>("idTipoEstagio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tipoestagioid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idTipoEstagio"));

                    b.Property<string>("descricaoTipoEstagio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("descricao");

                    b.HasKey("idTipoEstagio");

                    b.ToTable("tipoestagio");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.VagasModel", b =>
                {
                    b.Property<int>("VagasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("vagasid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VagasId"));

                    b.Property<DateTime>("DataLimite")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datalimite");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datapublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("descricao");

                    b.Property<string>("HorarioEntrada")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("horarioentrada");

                    b.Property<string>("HorarioSaida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("horariosaida");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("localidade");

                    b.Property<string>("LocalidadeTrabalho")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("localidadetrabalho");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("titulo");

                    b.Property<string>("TotalHorasSemanis")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("totalhorassemanais");

                    b.Property<int>("concedenteId")
                        .HasColumnType("integer");

                    b.HasKey("VagasId");

                    b.HasIndex("concedenteId");

                    b.ToTable("vagas");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.CargoModel", b =>
                {
                    b.HasOne("TechVagas_EstagioTech.Model.Entities.VagasModel", "Vagas")
                        .WithMany("Cargos")
                        .HasForeignKey("VagasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.VagasModel", b =>
                {
                    b.HasOne("TechVagas_EstagioTech.Model.Entities.ConcedenteModel", "Concedente")
                        .WithMany("Vagas")
                        .HasForeignKey("concedenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concedente");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.ConcedenteModel", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("TechVagas_EstagioTech.Model.Entities.VagasModel", b =>
                {
                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}
