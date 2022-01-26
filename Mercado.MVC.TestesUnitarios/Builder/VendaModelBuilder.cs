using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class VendaModelBuilder : BuilderBase<VendaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<VendaModel>.CreateNew()
               .With(x => x.DataVenda = DateTime.Now)
               .With(x => x.IdCliente = 1)
               .With(x => x.IdProduto = 1)
               .With(x => x.Quantidade = 10)
               .With(x => x.ValorVenda = x.Quantidade * x.Produto.PrecoUnidade);
        }
    }
}
