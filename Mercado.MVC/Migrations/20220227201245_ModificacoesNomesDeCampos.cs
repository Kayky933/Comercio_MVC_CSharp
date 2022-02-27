using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.MVC.Migrations
{
    public partial class ModificacoesNomesDeCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorVenda",
                table: "Vendas",
                newName: "Valor_Venda");

            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "Vendas",
                newName: "Data_Venda");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Usuarios",
                newName: "Data_Nascimento");

            migrationBuilder.RenameColumn(
                name: "UnidadeDeMedida",
                table: "Produtos",
                newName: "Unidade_De_Medida");

            migrationBuilder.RenameColumn(
                name: "QuantidadeProduto",
                table: "Produtos",
                newName: "Quantidade_Produto");

            migrationBuilder.RenameColumn(
                name: "PrecoUnidade",
                table: "Produtos",
                newName: "Preco_Unidade");

            migrationBuilder.RenameColumn(
                name: "UltimaModificacao",
                table: "Fornecedores",
                newName: "Ultima_Modificacao");

            migrationBuilder.RenameColumn(
                name: "NumeroCasa",
                table: "Fornecedores",
                newName: "Numero_Casa");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Fornecedores",
                newName: "Data_Cadastro");

            migrationBuilder.RenameColumn(
                name: "ValorUnidade",
                table: "EntregaFornecedor",
                newName: "Valor_Unidade");

            migrationBuilder.RenameColumn(
                name: "DataEntrega",
                table: "EntregaFornecedor",
                newName: "Data_Entrega");

            migrationBuilder.RenameColumn(
                name: "UltimaModificacao",
                table: "Clientes",
                newName: "Ultima_Modificacao");

            migrationBuilder.RenameColumn(
                name: "NumeroCasa",
                table: "Clientes",
                newName: "Numero_Casa");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Clientes",
                newName: "Data_Cadastro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor_Venda",
                table: "Vendas",
                newName: "ValorVenda");

            migrationBuilder.RenameColumn(
                name: "Data_Venda",
                table: "Vendas",
                newName: "DataVenda");

            migrationBuilder.RenameColumn(
                name: "Data_Nascimento",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "Unidade_De_Medida",
                table: "Produtos",
                newName: "UnidadeDeMedida");

            migrationBuilder.RenameColumn(
                name: "Quantidade_Produto",
                table: "Produtos",
                newName: "QuantidadeProduto");

            migrationBuilder.RenameColumn(
                name: "Preco_Unidade",
                table: "Produtos",
                newName: "PrecoUnidade");

            migrationBuilder.RenameColumn(
                name: "Ultima_Modificacao",
                table: "Fornecedores",
                newName: "UltimaModificacao");

            migrationBuilder.RenameColumn(
                name: "Numero_Casa",
                table: "Fornecedores",
                newName: "NumeroCasa");

            migrationBuilder.RenameColumn(
                name: "Data_Cadastro",
                table: "Fornecedores",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "Valor_Unidade",
                table: "EntregaFornecedor",
                newName: "ValorUnidade");

            migrationBuilder.RenameColumn(
                name: "Data_Entrega",
                table: "EntregaFornecedor",
                newName: "DataEntrega");

            migrationBuilder.RenameColumn(
                name: "Ultima_Modificacao",
                table: "Clientes",
                newName: "UltimaModificacao");

            migrationBuilder.RenameColumn(
                name: "Numero_Casa",
                table: "Clientes",
                newName: "NumeroCasa");

            migrationBuilder.RenameColumn(
                name: "Data_Cadastro",
                table: "Clientes",
                newName: "DataCadastro");
        }
    }
}
