using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    public class EntregaFornecedorModel
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnidade { get; set; }
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }
        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public FornecedorModel Fornecedor { get; set; }
        public DateTime DataEntrega { get; set; }

    }
}
