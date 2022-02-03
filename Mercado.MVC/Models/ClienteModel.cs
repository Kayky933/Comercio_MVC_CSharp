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
        public ICollection<VendaModel> Venda { get; set; }
    }
}
