﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PecaBoa.Infra.Context;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230322231340_AddDefauktAdministrador")]
    partial class AddDefauktAdministrador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PecaBoa.Domain.Entities.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoResetarSenha")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime?>("CodigoResetarSenhaExpiraEm")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool?>("Inadiplente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NomeSocial")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Lojista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("CodigoResetarSenha")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime?>("CodigoResetarSenhaExpiraEm")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NomeSocial")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("Id");

                    b.ToTable("Lojistaes");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.ProdutoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int>("LojistaId")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("Id");

                    b.HasIndex("LojistaId");

                    b.ToTable("ProdutoServicos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.ProdutoServico", b =>
                {
                    b.HasOne("PecaBoa.Domain.Entities.Lojista", "Lojista")
                        .WithMany("ProdutoServicos")
                        .HasForeignKey("LojistaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lojista");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Lojista", b =>
                {
                    b.Navigation("ProdutoServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
