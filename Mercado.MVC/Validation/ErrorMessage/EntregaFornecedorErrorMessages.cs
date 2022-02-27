namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class EntregaFornecedorErrorMessages
    {
        public static string DataNula = "O Campo Data não pode ser nula!";
        public static string DataFutura = "O Campo Data não pode ser futura";

        public static string Id_FornecedorNulo = "O Campo Fornecedor não pode ser nulo!";
        public static string Id_FornecedorTipoInvalido = "O Campo Fornecedor esta em um formato desconhecido!";
        public static string Id_FornecedorNaoEncontrado = "O Fornecedor selecionado não consta em nosso banco de dados!";

        public static string Id_ProdutoNulo = "O Campo Produto não pode ser nulo!";
        public static string Id_ProdutoTipoInvalido = "O Campo Produto esta em um formato desconhecido!";
        public static string Id_ProdutoNaoEncontrado = "O Produto selecionado não consta em nosso banco de dados!";

        public static string QuantidadeNula = "O Campo Quantidade não pode ser nulo!";
        public static string QuantidadeTipoInvalido = "O Campo Quantidade esta em um formato desconhecido!";
        public static string QuantidadeMinima = "O Campo Quantidade tem que ter no mínimo 1 unidade!";
        public static string QuantidadeMaxima = "O Campo Quantidade suporte no máximo 1000000000 unidades!";

        public static string Valor_UnidadeNulo = "O Campo Valor não pode ser nulo!";
        public static string Valor_UnidadeTipoInvalido = "O Campo Valor esta em um formato desconhecido!";
        public static string Valor_UnidadeMinimo = "O Campo Valor tem que ter no mínimo 1 unidade!";
        public static string Valor_UnidadeMaximo = "O Campo Valor suporte no máximo 1000000000 unidades!";
    }
}
