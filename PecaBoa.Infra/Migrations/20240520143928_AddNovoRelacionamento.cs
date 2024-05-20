using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddNovoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Usuarios_UsuarioId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Lojistas_LojistaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "PedidoCaracteristicas");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PrecoDesconto",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pedidos",
                newName: "NomePeca");

            migrationBuilder.RenameColumn(
                name: "LojistaId",
                table: "Pedidos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_LojistaId",
                table: "Pedidos",
                newName: "IX_Pedidos_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Orcamentos",
                newName: "LojistaId");

            migrationBuilder.RenameColumn(
                name: "DataDeEntrega",
                table: "Orcamentos",
                newName: "PrazoDeEntrega");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_UsuarioId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_LojistaId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnoDeFabricacao",
                table: "Pedidos",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Pedidos",
                type: "character varying(180)",
                maxLength: 180,
                nullable: false,
                defaultValue: "");

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
                name: "CondicaoDaPeca",
                table: "Orcamentos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Orcamentos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto2",
                table: "Orcamentos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto3",
                table: "Orcamentos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto4",
                table: "Orcamentos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto5",
                table: "Orcamentos",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Orcamentos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Lojistas_LojistaId",
                table: "Orcamentos",
                column: "LojistaId",
                principalTable: "Lojistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Lojistas_LojistaId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "AnoDeFabricacao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CondicaoDaPeca",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Foto2",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Foto3",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Foto4",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Foto5",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Orcamentos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pedidos",
                newName: "LojistaId");

            migrationBuilder.RenameColumn(
                name: "NomePeca",
                table: "Pedidos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                newName: "IX_Pedidos_LojistaId");

            migrationBuilder.RenameColumn(
                name: "PrazoDeEntrega",
                table: "Orcamentos",
                newName: "DataDeEntrega");

            migrationBuilder.RenameColumn(
                name: "LojistaId",
                table: "Orcamentos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_LojistaId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_UsuarioId");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Pedidos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoDesconto",
                table: "Pedidos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "PedidoCaracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    Chave = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Valor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCaracteristicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCaracteristicas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCaracteristicas_PedidoId",
                table: "PedidoCaracteristicas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Usuarios_UsuarioId",
                table: "Orcamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Lojistas_LojistaId",
                table: "Pedidos",
                column: "LojistaId",
                principalTable: "Lojistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
