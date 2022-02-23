using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class UsuarioModelBuilder : BuilderBase<UsuarioModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<UsuarioModel>.CreateNew()
                .With(x => x.Nome = "João")
                .With(x => x.Email = "joao@gmail.com")
                .With(x => x.Senha = "12345678")
                .With(x => x.DataNascimento = DateTime.Today.AddYears(-18));
        }
    }
}
