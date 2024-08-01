using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddInscricaoELojistaCartaoDeCredito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscricoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LojistaId = table.Column<int>(type: "integer", nullable: false),
                    Desativado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    EhRecorrente = table.Column<bool>(type: "boolean", nullable: false),
                    InscricaoAcabaEm = table.Column<DateTime>(type: "date", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricoes_Lojistas_LojistaId",
                        column: x => x.LojistaId,
                        principalTable: "Lojistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LojistaCartoesDeCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HolderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastNumbers = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    ExpiryMonth = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ExpiryYear = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Ccv = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    AddressNumber = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreditCardToken = table.Column<string>(type: "text", nullable: true),
                    LojistaId = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LojistaCartoesDeCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LojistaCartoesDeCredito_Lojistas_LojistaId",
                        column: x => x.LojistaId,
                        principalTable: "Lojistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_LojistaId",
                table: "Inscricoes",
                column: "LojistaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LojistaCartoesDeCredito_LojistaId",
                table: "LojistaCartoesDeCredito",
                column: "LojistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscricoes");

            migrationBuilder.DropTable(
                name: "LojistaCartoesDeCredito");
        }
    }
}
