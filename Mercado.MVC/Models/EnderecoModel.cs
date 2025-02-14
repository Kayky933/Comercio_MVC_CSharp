﻿using Mercado.MVC.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models
{

    public class EnderecoModel
    {
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        [MaxLength(9)]
        public string CEP { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Bairro { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Endereco { get; set; }

        [MaxLength(6)]
        [Required(ErrorMessage = "O Campo é obrigatório!")]
        public string Numero_Casa { get; set; }

        public UnidadeFederalEnum Uf { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }
    }
}
