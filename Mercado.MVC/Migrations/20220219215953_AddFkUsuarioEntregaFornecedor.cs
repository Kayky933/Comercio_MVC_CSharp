using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddFkUsuarioEntregaFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "EntregaFornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntregaFornecedor_Id_Usuario",
                table: "EntregaFornecedor",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Usuarios_Id_Usuario",
                table: "EntregaFornecedor",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Usuarios_Id_Usuario",
                table: "EntregaFornecedor");

            migrationBuilder.DropIndex(
                name: "IX_EntregaFornecedor_Id_Usuario",
                table: "EntregaFornecedor");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "EntregaFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
