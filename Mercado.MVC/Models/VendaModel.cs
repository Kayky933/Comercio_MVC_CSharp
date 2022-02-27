using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Vendas")]
    public class VendaModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Produto")]
        public Guid Id_Produto { get; set; }
        public ProdutoModel Produto { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor_Venda { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Cliente")]
        public Guid Id_Cliente { get; set; }

        public ClienteModel Cliente { get; set; }

        [ForeignKey("Usuario")]
        public Guid Id_Usuario { get; set; }
        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }

        public DateTime Data_Venda { get; set; } = DateTime.Now;
    }
}
