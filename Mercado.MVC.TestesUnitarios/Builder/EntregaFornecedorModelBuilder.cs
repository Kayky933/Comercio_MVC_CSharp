using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class EntregaFornecedorModelBuilder : BuilderBase<EntregaFornecedorModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<EntregaFornecedorModel>.CreateNew()
               .With(x => x.Data_Entrega = DateTime.Now)
               .With(x => x.Id_Fornecedor = Guid.NewGuid())
               .With(x => x.Id_Produto = Guid.NewGuid())
               .With(x => x.Quantidade = 10)
               .With(x => x.Valor_Unidade = 10);
        }
    }
}
