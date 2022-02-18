using Mercado.MVC.Models.Enum;
using System;
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
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal PrecoUnidade { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public double QuantidadeProduto { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public UnidadeMedidaEnum UnidadeDeMedida { get; set; }
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public CategoriaModel Categoria { get; set; }
        public ICollection<VendaModel> Vendas { get; set; }
        public DateTime DataAddProduto { get; set; } = DateTime.Now;

    }
}
