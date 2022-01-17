using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{
    public class FornecedorModel : PessoaModel
    {
        [MaxLength(18)]
        public string CNPJ { get; set; }
    }
}
