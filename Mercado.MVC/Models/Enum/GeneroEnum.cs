﻿using System.ComponentModel.DataAnnotations;

namespace Mercado.MVC.Models.Enum
{
    public enum GeneroEnum
    {
        Selecione = 0,
        Masculino = 1,
        Feminino = 2,
        [Display(Name = "Prefiro não informar")]
        Outros = 3
    }
}
