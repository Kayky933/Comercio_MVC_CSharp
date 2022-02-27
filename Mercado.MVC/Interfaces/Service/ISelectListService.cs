using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ISelectListService
    {
        public SelectList SelectProdutoModel(Guid idUsuario, string idModelString, string selectValue);
        public SelectList SelectClienteModel(Guid idUsuario, string idModelString, string selectValue);
        public SelectList SelectCategoriaModel(Guid idUsuario, string idModelString, string selectValue);
        public SelectList SelectFornecedorModel(Guid idUsuario, string idModelString, string selectValue);
        public SelectList SelectUnidadeMedida();
        public SelectList SelecListUF();
        public SelectList SelectListSexo();
    }
}
