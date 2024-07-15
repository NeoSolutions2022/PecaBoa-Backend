using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddDataFimPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Pedidos",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLimite",
                table: "Pedidos",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataLimite",
                table: "Pedidos");
        }
    }
}
