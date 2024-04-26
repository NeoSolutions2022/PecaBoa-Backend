using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddBairroUsuarioELojista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Lojistaes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Lojistaes");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuarios");
        }
    }
}
