using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddDescriptionLojista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Lojistaes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Lojistaes");
        }
    }
}
