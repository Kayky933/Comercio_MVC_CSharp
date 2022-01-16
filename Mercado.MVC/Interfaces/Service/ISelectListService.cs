using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ISelectListService
    {
        public SelectList SelectProdutoModel(string idModelString, string selectValue);
        public SelectList SelectClienteModel(string idModelString, string selectValue);
        public SelectList SelectCategoriaModel(string idModelString, string selectValue);
        public SelectList SelectUnidadeMedida();
        public SelectList SelecListUF();
        public SelectList SelectListSexo();
    }
}
