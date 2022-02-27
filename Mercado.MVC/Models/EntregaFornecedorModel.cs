using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("EntregaFornecedor")]
    public class EntregaFornecedorModel
    {
        [Key]
        public Guid Id { get; set; }

        public double Quantidade { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor_Unidade { get; set; }

        [ForeignKey("Produto")]
        public Guid Id_Produto { get; set; }
        public ProdutoModel Produto { get; set; }

        [ForeignKey("Fornecedor")]
        public Guid Id_Fornecedor { get; set; }
        public FornecedorModel Fornecedor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Data_Entrega { get; set; } = DateTime.Now;

        [ForeignKey("Usuario")]
        public Guid Id_Usuario { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }
    }
}