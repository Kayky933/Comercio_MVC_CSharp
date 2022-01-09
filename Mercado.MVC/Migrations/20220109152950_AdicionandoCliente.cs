using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class AdicionandoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razao_Social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nome_Fantasia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdCliente",
                table: "Vendas",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_IdCliente",
                table: "Vendas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_IdCliente",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Vendas");
        }
    }
}
