using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddCategoriaParaLojistaEProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "ProdutoServicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Lojistaes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "ProdutoServicos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Lojistaes");
        }
    }
}
