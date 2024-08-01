using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class UpdateRelacionamentoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TipoDePecas_TipoDePecaId",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos",
                column: "CategoriaVeiculoId",
                principalTable: "CategoriaVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TipoDePecas_TipoDePecaId",
                table: "Pedidos",
                column: "TipoDePecaId",
                principalTable: "TipoDePecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TipoDePecas_TipoDePecaId",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_CategoriaVeiculos_CategoriaVeiculoId",
                table: "Pedidos",
                column: "CategoriaVeiculoId",
                principalTable: "CategoriaVeiculos",
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
    }
}
