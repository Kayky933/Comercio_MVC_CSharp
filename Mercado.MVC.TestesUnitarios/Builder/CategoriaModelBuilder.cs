using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class CategoriaModelBuilder : BuilderBase<CategoriaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CategoriaModel>.CreateNew()
            .With(x => x.DataAddCategoria = DateTime.Now)
            .With(x => x.Descricao = "Enlatados");
        }
    }
}
