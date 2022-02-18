using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{
    public class FornecedorModel : PessoaModel
    {
        [MaxLength(19)]
        public string CNPJ { get; set; }

    }
}
