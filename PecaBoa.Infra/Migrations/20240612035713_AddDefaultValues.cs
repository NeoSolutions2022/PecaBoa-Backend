using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var criadoEm = new DateTime(2024, 6, 12, 0, 0, 0, DateTimeKind.Utc);
            var atualizadoEm = new DateTime(2024, 6, 12, 0, 0, 0, DateTimeKind.Utc);
            
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 1, "Anúncio Ativo", criadoEm, atualizadoEm, false, false },
                    { 2, "Vendido", criadoEm, atualizadoEm, false, false },
                    { 3, "Comprado", criadoEm, atualizadoEm, false, false },
                    { 4, "Cancelado", criadoEm, atualizadoEm, false, false }
                });
            
            migrationBuilder.InsertData(
                table: "TipoDePecas",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 1, "Peça do Motor", criadoEm, atualizadoEm, false, false },
                    { 2, "Peça da Transmissão", criadoEm, atualizadoEm, false, false },
                    { 3, "Peça da Suspensão", criadoEm, atualizadoEm, false, false },
                    { 4, "Peça do sistema de Freios", criadoEm, atualizadoEm, false, false },
                    { 5, "Peça da parte Elétrica", criadoEm, atualizadoEm, false, false },
                    { 6, "Peça da Carroceria", criadoEm, atualizadoEm, false, false },
                    { 7, "Peça do interior", criadoEm, atualizadoEm, false, false },
                    { 8, "Peça do sistema de exaustão", criadoEm, atualizadoEm, false, false },
                    { 9, "Peça do sistema de Direção", criadoEm, atualizadoEm, false, false },
                    { 10, "Pneus", criadoEm, atualizadoEm, false, false },
                    { 11, "Vidros", criadoEm, atualizadoEm, false, false }
                });
            
            migrationBuilder.InsertData(
                table: "CondicaoPecas",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 1, "Peça Nova", criadoEm, atualizadoEm, false, false },
                    { 2, "Peça Usada", criadoEm, atualizadoEm, false, false },
                    { 3, "Peça Recondicionada", criadoEm, atualizadoEm, false, false },
                    { 4, "Peça Danificada", criadoEm, atualizadoEm, false, false }

                });
            
            migrationBuilder.InsertData(
                table: "CategoriaVeiculos",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 1, "Sedan", criadoEm, atualizadoEm, false, false },
                    { 2, "SUV", criadoEm, atualizadoEm, false, false },
                    { 3, "Hatchback", criadoEm, atualizadoEm, false, false },
                    { 4, "Coupe", criadoEm, atualizadoEm, false, false },
                    { 5, "Convertible", criadoEm, atualizadoEm, false, false },
                    { 6, "Wagon", criadoEm, atualizadoEm, false, false },
                    { 7, "Van", criadoEm, atualizadoEm, false, false },
                    { 8, "Caminhão", criadoEm, atualizadoEm, false, false },
                    { 9, "Motocicleta", criadoEm, atualizadoEm, false, false },
                    { 10, "Elétrico", criadoEm, atualizadoEm, false, false },
                    { 11, "Híbrido", criadoEm, atualizadoEm, false, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });
            
            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            
            migrationBuilder.DeleteData(
                table: "CondicaoPecas",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });
            
            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        }
    }
}
