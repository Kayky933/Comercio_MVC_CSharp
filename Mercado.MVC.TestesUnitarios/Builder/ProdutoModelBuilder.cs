using FizzWare.NBuilder;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class ProdutoModelBuilder : BuilderBase<ProdutoModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<ProdutoModel>.CreateNew()
               .With(x => x.DataAddProduto = DateTime.Now)
               .With(x => x.Descricao = "Água")
               .With(x => x.IdCategoria = 1)
               .With(x => x.PrecoUnidade = 10.00M)
               .With(x => x.QuantidadeProduto = 10)
               .With(x => x.UnidadeDeMedida = UnidadeMedidaEnum.Litros);
        }
    }
}
