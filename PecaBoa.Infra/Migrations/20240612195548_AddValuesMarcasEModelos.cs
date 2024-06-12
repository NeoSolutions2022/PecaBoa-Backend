using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddValuesMarcasEModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var criadoEm = new DateTime(2024, 6, 12, 0, 0, 0, DateTimeKind.Utc);
            var atualizadoEm = new DateTime(2024, 6, 12, 0, 0, 0, DateTimeKind.Utc);
            
            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 1, "CHEVROLET", criadoEm, atualizadoEm, false, false },
                    { 2, "VOLKSWAGEN", criadoEm, atualizadoEm, false, false },
                    { 3, "FIAT", criadoEm, atualizadoEm, false, false },
                    { 4, "MERCEDES-BENZ", criadoEm, atualizadoEm, false, false },
                    { 5, "CITROEN", criadoEm, atualizadoEm, false, false },
                    { 6, "CHANA", criadoEm, atualizadoEm, false, false },
                    { 7, "HONDA", criadoEm, atualizadoEm, false, false },
                    { 8, "SUBARU", criadoEm, atualizadoEm, false, false },
                    { 10, "FERRARI", criadoEm, atualizadoEm, false, false },
                    { 11, "BUGATTI", criadoEm, atualizadoEm, false, false },
                    { 12, "LAMBORGHINI", criadoEm, atualizadoEm, false, false },
                    { 13, "FORD", criadoEm, atualizadoEm, false, false },
                    { 14, "HYUNDAI", criadoEm, atualizadoEm, false, false },
                    { 15, "JAC", criadoEm, atualizadoEm, false, false },
                    { 16, "KIA", criadoEm, atualizadoEm, false, false },
                    { 17, "GURGEL", criadoEm, atualizadoEm, false, false },
                    { 18, "DODGE", criadoEm, atualizadoEm, false, false },
                    { 19, "CHRYSLER", criadoEm, atualizadoEm, false, false },
                    { 20, "BENTLEY", criadoEm, atualizadoEm, false, false },
                    { 21, "SSANGYONG", criadoEm, atualizadoEm, false, false },
                    { 22, "PEUGEOT", criadoEm, atualizadoEm, false, false },
                    { 23, "TOYOTA", criadoEm, atualizadoEm, false, false },
                    { 24, "RENAULT", criadoEm, atualizadoEm, false, false },
                    { 25, "ACURA", criadoEm, atualizadoEm, false, false },
                    { 26, "ADAMO", criadoEm, atualizadoEm, false, false },
                    { 27, "AGRALE", criadoEm, atualizadoEm, false, false },
                    { 28, "ALFA ROMEO", criadoEm, atualizadoEm, false, false },
                    { 29, "AMERICAR", criadoEm, atualizadoEm, false, false },
                    { 31, "ASTON MARTIN", criadoEm, atualizadoEm, false, false },
                    { 32, "AUDI", criadoEm, atualizadoEm, false, false },
                    { 34, "BEACH", criadoEm, atualizadoEm, false, false },
                    { 35, "BIANCO", criadoEm, atualizadoEm, false, false },
                    { 36, "BMW", criadoEm, atualizadoEm, false, false },
                    { 37, "BORGWARD", criadoEm, atualizadoEm, false, false },
                    { 38, "BRILLIANCE", criadoEm, atualizadoEm, false, false },
                    { 41, "BUICK", criadoEm, atualizadoEm, false, false },
                    { 42, "CBT", criadoEm, atualizadoEm, false, false },
                    { 43, "NISSAN", criadoEm, atualizadoEm, false, false },
                    { 44, "CHAMONIX", criadoEm, atualizadoEm, false, false },
                    { 46, "CHEDA", criadoEm, atualizadoEm, false, false },
                    { 47, "CHERY", criadoEm, atualizadoEm, false, false },
                    { 48, "CORD", criadoEm, atualizadoEm, false, false },
                    { 49, "COYOTE", criadoEm, atualizadoEm, false, false },
                    { 50, "CROSS LANDER", criadoEm, atualizadoEm, false, false },
                    { 51, "DAEWOO", criadoEm, atualizadoEm, false, false },
                    { 52, "DAIHATSU", criadoEm, atualizadoEm, false, false },
                    { 53, "VOLVO", criadoEm, atualizadoEm, false, false },
                    { 54, "DE SOTO", criadoEm, atualizadoEm, false, false },
                    { 55, "DETOMAZO", criadoEm, atualizadoEm, false, false },
                    { 56, "DELOREAN", criadoEm, atualizadoEm, false, false },
                    { 57, "DKW-VEMAG", criadoEm, atualizadoEm, false, false },
                    { 59, "SUZUKI", criadoEm, atualizadoEm, false, false },
                    { 60, "EAGLE", criadoEm, atualizadoEm, false, false },
                    { 61, "EFFA", criadoEm, atualizadoEm, false, false }
                });
            
            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "MarcaId", "Nome", "CriadoEm", "AtualizadoEm", "CriadoPorAdmin", "AtualizadoPorAdmin" },
                values: new object[,]
                {
                    { 4991, 1, "CLASSIC", criadoEm, atualizadoEm, false, false },
                    { 4992, 21, "ACTYON", criadoEm, atualizadoEm, false, false },
                    { 5003, 1, "MARAJO", criadoEm, atualizadoEm, false, false },
                    { 5004, 1, "SUPREMA", criadoEm, atualizadoEm, false, false },
                    { 5005, 2, "NEW BEETLE", criadoEm, atualizadoEm, false, false },
                    { 5006, 2, "QUANTUM", criadoEm, atualizadoEm, false, false },
                    { 5007, 2, "CROSSFOX", criadoEm, atualizadoEm, false, false },
                    { 5008, 3, "MILLE", criadoEm, atualizadoEm, false, false },
                    { 5012, 3, "MOBI", criadoEm, atualizadoEm, false, false },
                    { 5013, 3, "TORO", criadoEm, atualizadoEm, false, false },
                    { 5015, 24, "DUSTER OROCH", criadoEm, atualizadoEm, false, false },
                    { 5016, 24, "SANDERO RS", criadoEm, atualizadoEm, false, false },
                    { 5017, 14, "HB20R", criadoEm, atualizadoEm, false, false },
                    { 5018, 14, "GRAND SANTA FE", criadoEm, atualizadoEm, false, false },
                    { 5019, 2, "GOLF VARIANT", criadoEm, atualizadoEm, false, false },
                    { 5020, 2, "SPACE CROSS", criadoEm, atualizadoEm, false, false },
                    { 5021, 22, "2008", criadoEm, atualizadoEm, false, false },
                    { 5022, 16, "QUORIS", criadoEm, atualizadoEm, false, false },
                    { 5023, 16, "GRAND CARNIVAL", criadoEm, atualizadoEm, false, false },
                    { 5024, 15, "T8", criadoEm, atualizadoEm, false, false },
                    { 5025, 15, "T6", criadoEm, atualizadoEm, false, false },
                    { 5026, 15, "T5", criadoEm, atualizadoEm, false, false },
                    { 5027, 13, "KA SEDAN", criadoEm, atualizadoEm, false, false },
                    { 5028, 13, "FOCUS FASTBACK", criadoEm, atualizadoEm, false, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValues: new object[] 
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 34, 35, 36, 37, 38, 
                    41, 42, 43, 44, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 
                    59, 60, 61
                });
            
            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    4991, 4992, 5003, 5004, 5005, 5006, 5007, 5008, 
                    5012, 5013, 5015, 5016, 5017, 5018, 5019, 5020,
                    5021, 5022, 5023, 5024, 5025, 5026, 5027, 5028
                });
        }
    }
}
