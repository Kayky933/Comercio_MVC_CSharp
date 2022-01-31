namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class ProdutoErrorMessages
    {
        public static string DescircaoProdutoNula = "A campo Descrição não pode ser nula!"!;
        public static string TamanhoMaximoDescricao = "A campo Descrição não pode ter mais que 100 caracteres!"!;
        public static string TamanhiMinimoDescricao = "A campo Descrição deve ter no mínimo 3 caracteres!"!;

        public static string PrecoNulo = "O campo Preço não pode ser nulo"!;
        public static string PrecoMinimo = "O campo Preço tem que ter no mínimo R$0,99"!;
        public static string PrecoMaximo = "O campo Preço suporte no máximo R$10000000000000000,00";
        public static string PrecoFormatoInvalido = "O campo Preço esta em um formato inválido"!;

        public static string QuantidadeProdNula = "O campo Quantidade não pode ser nulo"!;
        public static string QuantidadeProdMinima = "O campo Quantidade tem que ter no mínimo 1 unidade!"!;
        public static string QuantidadeMaxima = "O Campo Quantidade suporte no máximo o valor 10000000000000000!";
        public static string QuantidadeProdFormatoInvalido = "O campo Quantidade esta em um formato desconhecido!"!;

        public static string IdCategoriaNulo = "O campo Categoria não pode ser nulo"!;
        public static string IdCategoriaInexistente = "O campo Categoria selecionado não exsite, verifique as categorias criadas"!;

        public static string UnidadeMedidaNula = "O campo Unidade de Medida não pode ser nulo"!;
        public static string UnidadeMedidaFormatoInvalido = "O campo Unidade de Medida esta em um formato inválido"!;
        public static string UnidadeMedidaSelecionar = "Selecione uma unidade de medida"!;
    }
}
