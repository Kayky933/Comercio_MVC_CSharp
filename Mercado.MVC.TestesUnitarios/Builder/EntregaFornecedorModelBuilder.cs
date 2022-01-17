using FizzWare.NBuilder;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class EntregaFornecedorModelBuilder : BuilderBase<EntregaFornecedorModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<EntregaFornecedorModel>.CreateNew()
               .With(x => x.DataEntrega = DateTime.UtcNow)
               .With(x => x.IdFornecedor = 1)
               .With(x => x.IdProduto = 1)
               .With(x => x.Quantidade = 10)
               .With(x => x.ValorUnidade = 10);
        }
    }
}
