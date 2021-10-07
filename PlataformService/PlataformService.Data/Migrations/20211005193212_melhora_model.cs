using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlataformService.Data.Migrations
{
    public partial class melhora_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Platforms",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Platforms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Platforms",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Platforms",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Platforms");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Platforms",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);
        }
    }
}
