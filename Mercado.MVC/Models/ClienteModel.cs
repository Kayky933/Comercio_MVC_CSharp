using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Clientes")]
    public class ClienteModel : PessoaModel
    {
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(14)]
        public string CPF { get; set; }

        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }

        public ICollection<VendaModel> Vendas { get; set; }

    }
}
