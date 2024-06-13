using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PecaBoa.Infra.Migrations
{
    public partial class AddGrupoAcessoAndPermissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Administrador = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Desativado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposAcesso_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Categoria = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Desativado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true),
                    AtualizadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAcessoPermissao",
                columns: table => new
                {
                    GrupoAcessoId = table.Column<int>(type: "integer", nullable: false),
                    PermissaoId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CriadoPor = table.Column<int>(type: "integer", nullable: true),
                    CriadoPorAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAcessoPermissao", x => new { x.GrupoAcessoId, x.PermissaoId });
                    table.ForeignKey(
                        name: "FK_GrupoAcessoPermissao_GruposAcesso_GrupoAcessoId",
                        column: x => x.GrupoAcessoId,
                        principalTable: "GruposAcesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoAcessoPermissao_Permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAcessoPermissao_PermissaoId",
                table: "GrupoAcessoPermissao",
                column: "PermissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoAcessoPermissao");

            migrationBuilder.DropTable(
                name: "GruposAcesso");

            migrationBuilder.DropTable(
                name: "Permissoes");
        }
    }
}
