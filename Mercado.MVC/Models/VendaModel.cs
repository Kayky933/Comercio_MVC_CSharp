using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Vendas")]
    public class VendaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }
        public decimal Valor()
        {
            var valor = 0m;
            return valor += Produto.PrecoUnidade * Quantidade;
        }
    }
}
