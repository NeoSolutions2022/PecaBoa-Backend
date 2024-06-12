using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddTipoPecaEStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TipoDePeca",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CondicaoDaPeca",
                table: "Orcamentos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaVeiculoId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModeloId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePecaId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPecaId",
                table: "Orcamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Orcamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriaVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CondicaoPecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoPecas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDePecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDePecas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    MarcaId = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CategoriaVeiculoId",
                table: "Pedidos",
                column: "CategoriaVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MarcaId",
                table: "Pedidos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ModeloId",
                table: "Pedidos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_StatusId",
                table: "Pedidos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoDePecaId",
                table: "Pedidos",
                column: "TipoDePecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_CondicaoPecaId",
                table: "Orcamentos",
                column: "CondicaoPecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_StatusId",
                table: "Orcamentos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_CondicaoPecas_CondicaoPecaId",
                table: "Orcamentos",
                column: "CondicaoPecaId",
                principalTable: "CondicaoPecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Status_StatusId",
                table: "Orcamentos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos",
                column: "CategoriaVeiculoId",
                principalTable: "CategoriaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Marcas_MarcaId",
                table: "Pedidos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Modelos_ModeloId",
                table: "Pedidos",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TipoDePecas_TipoDePecaId",
                table: "Pedidos",
                column: "TipoDePecaId",
                principalTable: "TipoDePecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_CondicaoPecas_CondicaoPecaId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Status_StatusId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Marcas_MarcaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Modelos_ModeloId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TipoDePecas_TipoDePecaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "CategoriaVeiculos");

            migrationBuilder.DropTable(
                name: "CondicaoPecas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipoDePecas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CategoriaVeiculoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_MarcaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ModeloId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_StatusId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_TipoDePecaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_CondicaoPecaId",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_StatusId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "CategoriaVeiculoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TipoDePecaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CondicaoPecaId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orcamentos");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Pedidos",
                type: "character varying(180)",
                maxLength: 180,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Pedidos",
                type: "character varying(280)",
                maxLength: 280,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDePeca",
                table: "Pedidos",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CondicaoDaPeca",
                table: "Orcamentos",
                type: "text",
                nullable: true);
        }
    }
}
