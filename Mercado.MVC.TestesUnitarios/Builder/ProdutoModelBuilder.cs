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
               .With(x => x.Id_Categoria = Guid.NewGuid())
               .With(x => x.Preco_Unidade = 10.00M)
               .With(x => x.Quantidade_Produto = 10)
               .With(x => x.Unidade_De_Medida = UnidadeMedidaEnum.Litros);
        }
    }
}
