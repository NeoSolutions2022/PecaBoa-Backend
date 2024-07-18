using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AdjusteDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Mecânica"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Lataria e acabamento externo"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Elétrica, faróis e lanternas"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Painéis, bancos e acabamento interno"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nome",
                value: "Vidros"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Outros"
            );
            
            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 7
            );

            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 8
            );

            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 9
            );

            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 10
            );

            migrationBuilder.DeleteData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 11
            );
            
            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Carro"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Caminhonete"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Moto"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Caminhão"
            );
            
            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 5
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 6
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 7
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 8
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 9
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 10
            );

            migrationBuilder.DeleteData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 11
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Peça do Motor"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Peça da Transmissão"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Peça da Suspensão"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Peça do sistema de Freios"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nome",
                value: "Peça da parte Elétrica"
            );

            migrationBuilder.UpdateData(
                table: "TipoDePecas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Peça da Carroceria"
            );
            
            migrationBuilder.InsertData(
                table: "TipoDePecas",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 7, "Peça do interior", DateTime.Now, DateTime.Now, false, false },
                    { 8, "Peça do sistema de exaustão", DateTime.Now, DateTime.Now, false, false },
                    { 9, "Peça do sistema de Direção", DateTime.Now, DateTime.Now, false, false },
                    { 10, "Pneus", DateTime.Now, DateTime.Now, false, false },
                    { 11, "Vidros", DateTime.Now, DateTime.Now, false, false }
                });

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Sedan"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "SUV"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Hatchback"
            );

            migrationBuilder.UpdateData(
                table: "CategoriaVeiculos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Coupe"
            );
            
            migrationBuilder.InsertData(
                table: "CategoriaVeiculos",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 5, "Convertible", DateTime.Now, DateTime.Now, false, false },
                    { 6, "Wagon", DateTime.Now, DateTime.Now, false, false },
                    { 7, "Van", DateTime.Now, DateTime.Now, false, false },
                    { 8, "Caminhão", DateTime.Now, DateTime.Now, false, false },
                    { 9, "Motocicleta", DateTime.Now, DateTime.Now, false, false },
                    { 10, "Elétrico", DateTime.Now, DateTime.Now, false, false },
                    { 11, "Híbrido", DateTime.Now, DateTime.Now, false, false }
                });
        }
    }
}