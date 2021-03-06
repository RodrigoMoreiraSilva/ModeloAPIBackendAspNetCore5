// <auto-generated />
using System;
using GestaoUnica_backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoUnica_backend.Migrations
{
    [DbContext(typeof(SQLContext))]
    [Migration("20211109195154_Dominios_v1.1")]
    partial class Dominios_v11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestaoUnica_backend.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNAE")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CNAE");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<string>("DescricaoCNAE")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DescricaoCNAE");

                    b.Property<int?>("GrupoEmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("IE")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("IE");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("NomeFantasia");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("RazaoSocial");

                    b.HasKey("Id");

                    b.HasIndex("GrupoEmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("GestaoUnica_backend.Models.GrupoEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeAbreviado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NomeAbreviado");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.HasKey("Id");

                    b.ToTable("GrupoEmpresa");
                });

            modelBuilder.Entity("GestaoUnica_backend.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Area");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Email");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Nome")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nome");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("GestaoUnica_backend.Services.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcaoRealizada")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("AcaoRealizada");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.Property<int?>("RegraId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("RegraId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("GestaoUnica_backend.Services.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.HasKey("Id");

                    b.ToTable("Regras");
                });

            modelBuilder.Entity("GestaoUnica_backend.Services.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveDirectoryAuth")
                        .HasColumnType("bit")
                        .HasColumnName("ActiveDirectoryAuth");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInclusao");

                    b.Property<int>("IdUserAlteracao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserAlteracao");

                    b.Property<int>("IdUserInclusao")
                        .HasColumnType("int")
                        .HasColumnName("IdUserInclusao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Observacao");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Password");

                    b.Property<bool>("PasswordExpired")
                        .HasColumnType("bit")
                        .HasColumnName("PasswordExpired");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GestaoUnica_backend.Models.Empresa", b =>
                {
                    b.HasOne("GestaoUnica_backend.Models.GrupoEmpresa", "GrupoEmpresa")
                        .WithMany()
                        .HasForeignKey("GrupoEmpresaId");

                    b.Navigation("GrupoEmpresa");
                });

            modelBuilder.Entity("GestaoUnica_backend.Models.Pessoa", b =>
                {
                    b.HasOne("GestaoUnica_backend.Services.Models.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestaoUnica_backend.Services.Models.Log", b =>
                {
                    b.HasOne("GestaoUnica_backend.Services.Models.Role", "Regra")
                        .WithMany()
                        .HasForeignKey("RegraId");

                    b.Navigation("Regra");
                });
#pragma warning restore 612, 618
        }
    }
}
