using Mercado.MVC.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{
    public class PessoaModel : EnderecoModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Razao_Social { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Nome_Fantasia { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public DateTime Data_Nascimento { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(13)]
        public string RG { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(13)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(14)]
        public string Celular { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(14)]
        public string Whatsapp { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Email { get; set; }
        public SexoEnum Sexo { get; set; }
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UltimaModificacao { get; set; } = DateTime.UtcNow;
    }
}
