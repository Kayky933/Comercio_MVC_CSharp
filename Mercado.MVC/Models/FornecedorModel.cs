using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mercado.MVC.Models
{
    [Table("Fornecedores")]
    public class FornecedorModel : PessoaModel
    {
        [MaxLength(19)]
        public string CNPJ { get; set; }

        [ForeignKey("Usuario")]
        public Guid Id_Usuario { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioModel Usuario { get; set; }

        public ICollection<EntregaFornecedorModel> Entregas { get; set; }
    }
}
