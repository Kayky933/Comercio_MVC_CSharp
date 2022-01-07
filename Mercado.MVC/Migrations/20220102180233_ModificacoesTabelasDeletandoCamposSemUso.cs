using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class ModificacoesTabelasDeletandoCamposSemUso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoProduto",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "DescricaoCategoria",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoProduto",
                table: "Vendas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCategoria",
                table: "Produtos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
