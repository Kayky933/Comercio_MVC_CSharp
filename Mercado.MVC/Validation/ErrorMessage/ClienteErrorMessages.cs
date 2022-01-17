namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class ClienteErrorMessages
    {
        public static string RazaoSocialNula = "O campo Razão Social não pode ter nulo!";
        public static string RazaoSocialTamanhoMaximo = "O campo Razão Social não pode ter mais que 100 caracteres!";
        public static string RazaoSocialTamanhoMinimo = "O campo Razão Social não pode ter menos que 3 caracteres!";

        public static string NomeFantasiaNulo = "O campo Nome Fantasia não pode ter nulo!";
        public static string NomeFantasiaTamanhoMaximo = "O campo Nome Fantasia não pode ter mais que 100 caracteres!";
        public static string NomeFantasiaTamanhoMinimo = "O campo Nome Fantasia não pode ter menos que 3 carcateres!";

        public static string DataNascimentoNula = "O campo Data de Nascimento não pode ter nulo!";
        public static string DataNascimentoFormatoInvalido = "O campo Data de Nascimento Esta em um formato desconhecido!";
        public static string DataNascimentoIdadeMinima = "É preciso ser maior de idade para se cadastrar!";

        public static string RGNulo = "O campo RG não pode ter nulo!";
        public static string RGTamanho = "O campo RG tem um tamanho máximo e mínimo de 9 digitos!";

        public static string CPFNulo = "O campo CPF não pode ter nulo!";
        public static string CPFTamanho = "O campo RG tem um tamanho máximo e mínimo de 11 caracteres!";

        public static string CEPNulo = "O campo CEP não pode ter nulo!";
        public static string CEPTamanho = "O campo CEP tem um tamanho máximo e mínimo de 8 caracteres!";

        public static string BairroNulo = "O campo Bairro não pode ter nulo!";
        public static string BairroTamanhoMaximo = "O campo Bairro não pode ter mais que 100 caracteres!";
        public static string BairroTamanhoMinimo = "O campo Bairro não pode ter menos que 3 carcateres!";

        public static string EnderecoNulo = "O campo Endereco não pode ter nulo!";
        public static string EnderecoTamanhoMaximo = "O campo Endereco não pode ter mais que 100 caracteres!";
        public static string EnderecoTamanhoMinimo = "O campo Endereco não pode ter menos que 5 carcateres!";

        public static string NumeroNulo = "O campo Numero não pode ter nulo";
        public static string NumeroTamanhoMaximo = "O campo Numero não pode ter mais que 6 digitos!";
        public static string NumeroTamanhoMinimo = "O campo Numero não pode ter menos que 1 digito!";

        public static string UFNula = "O campo UF não pode ter nulo!";
        public static string UFFormatoInvalido = "O campo UF esta em um formato desconhecido!";

        public static string ComplementoTamanhoMaximo = "O campo Complemento não pode ter mais que 100 caracteres!";
        public static string ComplementoTamanhoMinimo = "O campo Complemento não pode ter menos que 5 carcateres!";

        public static string TelefoneTamanho = "O campo Telefone deve ter no mínimo 10 caracteres!";

        public static string CelularNulo = "O campo Celular não pode ter nulo!";
        public static string CelularTamanho = "O campo Telefone deve ter no mínimo 11 caracteres!";

        public static string WhatsappNulo = "O campo Whatsapp não pode ter nulo!";
        public static string WhatsappTamanho = "O campo Whatsapp deve ter no mínimo 11 caracteres!";

        public static string EmailNulo = "O campo Email não pode ter nulo!";
        public static string EmailTamanhoMaximo = "O campo Email não pode ter mais que 100 caracteres!";
        public static string EmailTamanhoMinimo = "O campo Email não pode ter menos que 7 carcateres!";
        public static string EmailFormato = "O campo Email esta em um formato desconhecido!";

        public static string SexoNulo = "o Campo Sexo não pdoe ser nulo!";
        public static string SexoFormatoInvalido = "O campo Sexo esta em um formato desconhecido!";

    }
}
