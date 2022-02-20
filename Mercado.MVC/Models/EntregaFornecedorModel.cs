using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("EntregaFornecedor")]
    public class EntregaFornecedorModel
    {
        [Key]
        public int Id { get; set; }

        public double Quantidade { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnidade { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public FornecedorModel Fornecedor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataEntrega { get; set; } = DateTime.Now;

        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }
    }
}