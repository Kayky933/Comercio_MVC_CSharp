using Mercado.MVC.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{
    public class UsuarioModel
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [MaxLength(70)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [MaxLength(14)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Escolha uma das opções")]

        public SexoEnum Sexo { get; set; }
    }
}
