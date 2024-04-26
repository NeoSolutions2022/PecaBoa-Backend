using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddPropriedadesDeAnuncioParaProdutoELojistaes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnuncioPago",
                table: "ProdutoServicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoAnuncio",
                table: "ProdutoServicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamentoAnuncio",
                table: "ProdutoServicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnuncioPago",
                table: "Lojistaes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoAnuncio",
                table: "Lojistaes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamentoAnuncio",
                table: "Lojistaes",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnuncioPago",
                table: "ProdutoServicos");

            migrationBuilder.DropColumn(
                name: "DataExpiracaoAnuncio",
                table: "ProdutoServicos");

            migrationBuilder.DropColumn(
                name: "DataPagamentoAnuncio",
                table: "ProdutoServicos");

            migrationBuilder.DropColumn(
                name: "AnuncioPago",
                table: "Lojistaes");

            migrationBuilder.DropColumn(
                name: "DataExpiracaoAnuncio",
                table: "Lojistaes");

            migrationBuilder.DropColumn(
                name: "DataPagamentoAnuncio",
                table: "Lojistaes");
        }
    }
}
