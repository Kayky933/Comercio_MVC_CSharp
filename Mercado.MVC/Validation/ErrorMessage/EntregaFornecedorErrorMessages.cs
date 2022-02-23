namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class EntregaFornecedorErrorMessages
    {
        public static string DataNula = "O Campo Data não pode ser nula!";
        public static string DataFutura = "O Campo Data não pode ser futura";

        public static string IdFornecedorNulo = "O Campo Fornecedor não pode ser nulo!";
        public static string IdFornecedorTipoInvalido = "O Campo Fornecedor esta em um formato desconhecido!";
        public static string IdFornecedorNaoEncontrado = "O Fornecedor selecionado não consta em nosso banco de dados!";

        public static string IdProdutoNulo = "O Campo Produto não pode ser nulo!";
        public static string IdProdutoTipoInvalido = "O Campo Produto esta em um formato desconhecido!";
        public static string IdProdutoNaoEncontrado = "O Produto selecionado não consta em nosso banco de dados!";

        public static string QuantidadeNula = "O Campo Quantidade não pode ser nulo!";
        public static string QuantidadeTipoInvalido = "O Campo Quantidade esta em um formato desconhecido!";
        public static string QuantidadeMinima = "O Campo Quantidade tem que ter no mínimo 1 unidade!";
        public static string QuantidadeMaxima = "O Campo Quantidade suporte no máximo 1000000000 unidades!";

        public static string ValorUnidadeNulo = "O Campo Valor não pode ser nulo!";
        public static string ValorUnidadeTipoInvalido = "O Campo Valor esta em um formato desconhecido!";
        public static string ValorUnidadeMinimo = "O Campo Valor tem que ter no mínimo 1 unidade!";
        public static string ValorUnidadeMaximo = "O Campo Valor suporte no máximo 1000000000 unidades!";
    }
}
