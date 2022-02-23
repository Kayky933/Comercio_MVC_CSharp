using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddFkUsuarioFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Id_Usuario",
                table: "Fornecedores",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Usuarios_Id_Usuario",
                table: "Fornecedores",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Usuarios_Id_Usuario",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_Id_Usuario",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Fornecedores");
        }
    }
}
