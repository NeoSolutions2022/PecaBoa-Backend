using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddPropTipoDePeca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caracteristica",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "TipoDePeca",
                table: "Pedidos",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDePeca",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "Caracteristica",
                table: "Pedidos",
                type: "character varying(8000)",
                maxLength: 8000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Pedidos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
