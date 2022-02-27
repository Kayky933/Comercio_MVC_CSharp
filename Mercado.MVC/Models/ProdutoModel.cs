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
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Preco_Unidade { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public double Quantidade_Produto { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public UnidadeMedidaEnum Unidade_De_Medida { get; set; }

        public DateTime DataAddProduto { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [ForeignKey("Categoria")]
        public Guid Id_Categoria { get; set; }
        public CategoriaModel Categoria { get; set; }

        [ForeignKey("Usuario")]
        public Guid Id_Usuario { get; set; }
        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }

        public ICollection<VendaModel> Vendas { get; set; }

        public ICollection<EntregaFornecedorModel> Entregas { get; set; }
    }
}
