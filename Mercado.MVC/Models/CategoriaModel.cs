using Newtonsoft.Json;
using System;
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

        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataAddCategoria { get; set; } = DateTime.Now;

        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
