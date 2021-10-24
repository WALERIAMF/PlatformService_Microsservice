using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlataformService.Data.Migrations
{
    public partial class add_cpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Colaboradores",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GrupoPermissaoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPermissaoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoPermissaoModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissaoDto_GrupoPermissaoModel_GrupoPermissaoModelId",
                        column: x => x.GrupoPermissaoModelId,
                        principalTable: "GrupoPermissaoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoPermissaoModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrupoPermissaoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissaoModel_GrupoPermissaoModel_GrupoPermissaoModelId",
                        column: x => x.GrupoPermissaoModelId,
                        principalTable: "GrupoPermissaoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissaoModel_GrupoPermissoes_GrupoPermissaoEntityId",
                        column: x => x.GrupoPermissaoEntityId,
                        principalTable: "GrupoPermissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoDto_GrupoPermissaoModelId",
                table: "PermissaoDto",
                column: "GrupoPermissaoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoModel_GrupoPermissaoEntityId",
                table: "PermissaoModel",
                column: "GrupoPermissaoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoModel_GrupoPermissaoModelId",
                table: "PermissaoModel",
                column: "GrupoPermissaoModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissaoDto");

            migrationBuilder.DropTable(
                name: "PermissaoModel");

            migrationBuilder.DropTable(
                name: "GrupoPermissaoModel");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Colaboradores");
        }
    }
}
