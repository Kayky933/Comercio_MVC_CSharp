namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class VendaErrorMessages
    {
        public static string QuantidadeNula = "O Campo Quantidade não pode ser nulo!";
        public static string QuantidadeMinima = "O Campo Quantidade não pode ter menos que 1 itens!";
        public static string QuantidadeTipoInvalido = "O Campo Quantidade não esta em um formato válido!";

        public static string IdProdutoNulo = "O Campo Produto não pode ser nulo!";
        public static string IdProdutoInexistente = "O Campo Produto não existe no banco de dados!";
    }
}
