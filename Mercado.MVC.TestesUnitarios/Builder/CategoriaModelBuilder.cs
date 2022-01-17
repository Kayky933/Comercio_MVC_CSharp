using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class CategoriaModelBuilder : BuilderBase<CategoriaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CategoriaModel>.CreateNew()
            .With(x => x.DataAddCategoria = DateTime.UtcNow)
            .With(x => x.Descricao = "Enlatados");
        }
    }
}
