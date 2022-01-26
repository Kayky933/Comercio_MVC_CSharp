using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Vendas")]
    public class VendaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorVenda { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public ClienteModel Cliente { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}
