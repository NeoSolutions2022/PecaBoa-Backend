using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddFotoLojistaEUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Lojistaes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Lojistaes");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Usuarios");
        }
    }
}
