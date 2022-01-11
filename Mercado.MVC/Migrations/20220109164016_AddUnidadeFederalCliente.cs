using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddUnidadeFederalCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Uf",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Clientes");
        }
    }
}
