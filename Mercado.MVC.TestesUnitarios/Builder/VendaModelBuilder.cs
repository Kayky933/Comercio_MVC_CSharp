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
               .With(x => x.Data_Venda = DateTime.Now)
               .With(x => x.Id_Cliente = Guid.NewGuid())
               .With(x => x.Id_Produto = Guid.NewGuid())
               .With(x => x.Quantidade = 10)
               .With(x => x.Valor_Venda = 10000000);
        }
    }
}
