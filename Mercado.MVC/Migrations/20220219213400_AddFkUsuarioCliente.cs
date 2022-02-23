using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AddFkUsuarioCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedorModel_FornecedorModel_IdFornecedor",
                table: "EntregaFornecedorModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedorModel_Produtos_IdProduto",
                table: "EntregaFornecedorModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedorModel",
                table: "FornecedorModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntregaFornecedorModel",
                table: "EntregaFornecedorModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "FornecedorModel",
                newName: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "EntregaFornecedorModel",
                newName: "EntregaFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaFornecedorModel_IdProduto",
                table: "EntregaFornecedor",
                newName: "IX_EntregaFornecedor_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaFornecedorModel_IdFornecedor",
                table: "EntregaFornecedor",
                newName: "IX_EntregaFornecedor_IdFornecedor");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntregaFornecedor",
                table: "EntregaFornecedor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id_Usuario",
                table: "Clientes",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_Id_Usuario",
                table: "Clientes",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_Id_Usuario",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Fornecedores_IdFornecedor",
                table: "EntregaFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaFornecedor_Produtos_IdProduto",
                table: "EntregaFornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Id_Usuario",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntregaFornecedor",
                table: "EntregaFornecedor");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "FornecedorModel");

            migrationBuilder.RenameTable(
                name: "EntregaFornecedor",
                newName: "EntregaFornecedorModel");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaFornecedor_IdProduto",
                table: "EntregaFornecedorModel",
                newName: "IX_EntregaFornecedorModel_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EntregaFornecedor_IdFornecedor",
                table: "EntregaFornecedorModel",
                newName: "IX_EntregaFornecedorModel_IdFornecedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedorModel",
                table: "FornecedorModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntregaFornecedorModel",
                table: "EntregaFornecedorModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedorModel_FornecedorModel_IdFornecedor",
                table: "EntregaFornecedorModel",
                column: "IdFornecedor",
                principalTable: "FornecedorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaFornecedorModel_Produtos_IdProduto",
                table: "EntregaFornecedorModel",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
