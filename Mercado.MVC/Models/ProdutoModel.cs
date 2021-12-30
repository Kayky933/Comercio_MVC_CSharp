using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal PrecoUnidade { get; set; }
        [Required]
        public double QuantidadeProduto { get; set; }
        [Required]
        public UnidadeMedidaEnum UnidadeDeMedida { get; set; }
        [Required]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public CategoriaModel Categoria { get; set; }
        [Required]
        [MaxLength(100)]
        public string DescricaoCategoria { get; set; }
        public ICollection<VendaModel> Vendas { get; set; }
    }
}
