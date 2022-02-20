using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddFkUsuarioProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Usuario",
                table: "Produtos",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_Id_Usuario",
                table: "Produtos",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_Id_Usuario",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Id_Usuario",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
