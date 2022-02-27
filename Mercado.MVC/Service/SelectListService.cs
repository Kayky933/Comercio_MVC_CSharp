using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
namespace Mercado.MVC.Service
{
    public class SelectListService : ISelectListService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorService _fornecedorService;

        public SelectListService(ICategoriaService categoriaService, IClienteService clienteService, IProdutoService produtoService, IFornecedorService fornecedorService)
        {
            _categoriaService = categoriaService;
            _clienteService = clienteService;
            _produtoService = produtoService;
            _fornecedorService = fornecedorService;
        }
        public SelectList SelectCategoriaModel(Guid idUsuario, string idModelString, string selectValue)
        {
            return new SelectList(_categoriaService.GetContext().Where(x => x.Id_Usuario == idUsuario).ToList(), idModelString, selectValue);
        }

        public SelectList SelectClienteModel(Guid idUsuario, string idModelString, string selectValue)
        {
            return new SelectList(_clienteService.GetContext().Where(x => x.Id_Usuario == idUsuario).ToList(), idModelString, selectValue);
        }

        public SelectList SelectProdutoModel(Guid idUsuario, string idModelString, string selectValue)
        {
            return new SelectList(_produtoService.GetContext().Where(x => x.Id_Usuario == idUsuario).ToList(), idModelString, selectValue);
        }
        public SelectList SelectFornecedorModel(Guid idUsuario, string idModelString, string selectValue)
        {
            return new SelectList(_fornecedorService.GetContext(), idModelString, selectValue);
        }
        public SelectList SelecListUF()
        {
            return new SelectList(Enum.GetValues(typeof(UnidadeFederalEnum)));
        }

        public SelectList SelectUnidadeMedida()
        {
            return new SelectList(Enum.GetValues(typeof(UnidadeMedidaEnum)));
        }

        public SelectList SelectListSexo()
        {
            return new SelectList(Enum.GetValues(typeof(GeneroEnum)));
        }
    }
}
