namespace Mercado.MVC.Validation.ErrorMessage
{
    public static class UsuarioErrorMessages
    {
        public static string NomeNulo = "O campo Nome Fantasia não pode ter nulo!";
        public static string NomeTamanhoMaximo = "O campo Nome Fantasia não pode ter mais que 100 caracteres!";
        public static string NomeTamanhoMinimo = "O campo Nome Fantasia não pode ter menos que 3 carcateres!";

        public static string EmailNulo = "O campo Email não pode ter nulo!";
        public static string EmailTamanhoMaximo = "O campo Email não pode ter mais que 100 caracteres!";
        public static string EmailTamanhoMinimo = "O campo Email não pode ter menos que 7 carcateres!";
        public static string EmailFormato = "O campo Email esta em um formato desconhecido!";
        public static string EmailJaCadastrado = "O E-mail inserido ja se encontra cadastrado!";

        public static string SenhaTamanhoMaximo = "A Senha suporte no máximo 80 caracteres!";
        public static string SenhaTamanhoMinimo = "A Senha deve ter no mínimo 8 caracteres!";
        public static string SenhaNula = "A Senha não pode ser nula!";

        public static string Data_NascimentoNula = "O campo Data de Nascimento não pode ter nulo!";
        public static string Data_NascimentoFormatoInvalido = "O campo Data de Nascimento Esta em um formato desconhecido!";
        public static string Data_NascimentoIdadeMinima = "É preciso ser maior de idade para se cadastrar!";
    }
}
