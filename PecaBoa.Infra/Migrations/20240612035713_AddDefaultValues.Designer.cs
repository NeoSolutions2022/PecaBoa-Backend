﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PecaBoa.Infra.Context;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240612035713_AddDefaultValues")]
    partial class AddDefaultValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PecaBoa.Domain.Entities.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CodigoResetarSenha")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime?>("CodigoResetarSenhaExpiraEm")
                        .HasColumnType("date");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.CategoriaVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaVeiculos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.CondicaoPeca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("CondicaoPecas");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Lojista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<Guid?>("CodigoResetarSenha")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime?>("CodigoResetarSenhaExpiraEm")
                        .HasColumnType("date");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("Id");

                    b.ToTable("Lojistas");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("MarcaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("CondicaoPecaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Foto")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto2")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto3")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto4")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto5")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<int>("LojistaId")
                        .HasColumnType("integer");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PrazoDeEntrega")
                        .HasColumnType("date");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CondicaoPecaId");

                    b.HasIndex("LojistaId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AnoDeFabricacao")
                        .HasColumnType("date");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("CategoriaVeiculoId")
                        .HasColumnType("integer");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto2")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto3")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto4")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Foto5")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("integer");

                    b.Property<int>("ModeloId")
                        .HasColumnType("integer");

                    b.Property<string>("NomePeca")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoDePecaId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaVeiculoId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoDePecaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.TipoDePeca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("TipoDePecas");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("AtualizadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<Guid?>("CodigoResetarSenha")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime?>("CodigoResetarSenhaExpiraEm")
                        .HasColumnType("date");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CriadoPor")
                        .HasColumnType("integer");

                    b.Property<bool>("CriadoPorAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("NomeSocial")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("PecaBoa.Domain.Entities.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Orcamento", b =>
                {
                    b.HasOne("PecaBoa.Domain.Entities.CondicaoPeca", "CondicaoPeca")
                        .WithMany("Orcamentos")
                        .HasForeignKey("CondicaoPecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Lojista", "Lojista")
                        .WithMany("Orcamentos")
                        .HasForeignKey("LojistaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Orcamentos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Status", "Status")
                        .WithMany("Orcamentos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CondicaoPeca");

                    b.Navigation("Lojista");

                    b.Navigation("Pedido");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("PecaBoa.Domain.Entities.CategoriaVeiculo", "CategoriaVeiculo")
                        .WithMany("Pedidos")
                        .HasForeignKey("CategoriaVeiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Marca", "Marca")
                        .WithMany("Pedidos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Pedidos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Status", "Status")
                        .WithMany("Pedidos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.TipoDePeca", "TipoDePeca")
                        .WithMany("Pedidos")
                        .HasForeignKey("TipoDePecaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PecaBoa.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaVeiculo");

                    b.Navigation("Marca");

                    b.Navigation("Modelo");

                    b.Navigation("Status");

                    b.Navigation("TipoDePeca");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.CategoriaVeiculo", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.CondicaoPeca", b =>
                {
                    b.Navigation("Orcamentos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Lojista", b =>
                {
                    b.Navigation("Orcamentos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Marca", b =>
                {
                    b.Navigation("Modelos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Orcamentos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Status", b =>
                {
                    b.Navigation("Orcamentos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.TipoDePeca", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PecaBoa.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
