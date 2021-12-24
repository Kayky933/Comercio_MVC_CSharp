using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Categorias")]
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
