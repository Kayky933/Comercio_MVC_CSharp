using Mercado.MVC.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{
    public class PessoaModel : EnderecoModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Razao_Social { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Nome_Fantasia { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime Data_Nascimento { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(13)]
        public string RG { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(14)]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(14)]
        [DataType(DataType.PhoneNumber)]
        public string Whatsapp { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public GeneroEnum Sexo { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime Data_Cadastro { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime Ultima_Modificacao { get; set; } = DateTime.Now;
    }
}
