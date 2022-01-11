using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class ClienteAddNumeroEComplemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCasa",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NumeroCasa",
                table: "Clientes");
        }
    }
}
