﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaTecnica.Repositorio;

namespace ProvaTecnica.Repositorio.Migrations
{
    [DbContext(typeof(DbEscolaContext))]
    partial class DbEscolaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProvaTecnica.Dominio.Aluno", b =>
                {
                    b.Property<int>("IdAluno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTurma");

                    b.Property<string>("NomeAluno");

                    b.Property<decimal>("NotaAluno");

                    b.HasKey("IdAluno");

                    b.HasIndex("IdTurma");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Escola", b =>
                {
                    b.Property<int>("IdEscola")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEscola");

                    b.HasKey("IdEscola");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoPerfil");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Turma", b =>
                {
                    b.Property<int>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEscola");

                    b.Property<string>("NomeTurma");

                    b.HasKey("IdTurma");

                    b.HasIndex("IdEscola");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPerfil");

                    b.Property<string>("NomeUsuario");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Aluno", b =>
                {
                    b.HasOne("ProvaTecnica.Dominio.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Turma", b =>
                {
                    b.HasOne("ProvaTecnica.Dominio.Escola", "Escola")
                        .WithMany()
                        .HasForeignKey("IdEscola")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProvaTecnica.Dominio.Usuario", b =>
                {
                    b.HasOne("ProvaTecnica.Dominio.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
