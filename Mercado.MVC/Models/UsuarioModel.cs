using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [MaxLength(80)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
