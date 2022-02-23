using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddFkUsuarioCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Id_Usuario",
                table: "Categorias",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_Id_Usuario",
                table: "Categorias",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_Id_Usuario",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_Id_Usuario",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Categorias");
        }
    }
}
