namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class VendaErrorMessages
    {
        public static string ValorVendaMaximo = "Valor da venda máximo atingido(R$1000000000,00)";
        public static string ValorMinimo = "Valor da venda deve ser no mínimo R$1,00!";
        public static string ValorVendaNulo = "O Valor da venda não pode ser nulo!";

        public static string QuantidadeNula = "O Campo Quantidade não pode ser nulo!";
        public static string QuantidadeMinima = "O Campo Quantidade não pode ter menos que 1 itens!";
        public static string QuantidadeMaxima = "O Campo Quantidade suporta no máximo o valor 1000000000!";
        public static string QuantidadeTipoInvalido = "O Campo Quantidade não esta em um formato válido!";
        public static string QuantidadeEstoqueEsgotada = "A Quantidade do pedido não existe no estoque!";



        public static string IdProdutoNulo = "O Campo Produto não pode ser nulo!";
        public static string IdProdutoInexistente = "O Campo Produto não existe no banco de dados!";
    }
}
