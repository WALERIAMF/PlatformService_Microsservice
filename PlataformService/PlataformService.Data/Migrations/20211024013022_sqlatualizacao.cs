using Microsoft.EntityFrameworkCore.Migrations;

namespace PlataformService.Data.Migrations
{
    public partial class sqlatualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Colaboradores",
                type: "varchar",
                precision: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Colaboradores",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldPrecision: 11);
        }
    }
}
