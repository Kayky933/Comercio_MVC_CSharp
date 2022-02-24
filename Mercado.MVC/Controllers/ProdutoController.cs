using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    [Authorize]
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _service;
        private readonly ICategoriaService _categoriaService;
        private readonly ISelectListService _selectListService;

        public ProdutoController(IProdutoService service, ICategoriaService categoriaService, ISelectListService selectListService)
        {
            _service = service;
            _categoriaService = categoriaService;
            _selectListService = selectListService;
        }

        // GET: Produto
        public IActionResult Index()
        {
            Autenticar();
            return View(_service.GetAll(ViewBag.usuarioId));
        }

        // GET: Produto/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = _service.GetOneById(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            Autenticar();
            ViewData["IdCategoria"] = _selectListService.SelectCategoriaModel("Id", "Descricao");
            ViewData["UnidaDeMedida"] = _selectListService.SelectUnidadeMedida();
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoModel produtoModel)
        {
            Autenticar();
            var response = _service.Create(produtoModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Produto");

            ViewData["IdCategoria"] = _selectListService.SelectCategoriaModel("Id", "Descricao");
            ViewData["UnidaDeMedida"] = _selectListService.SelectUnidadeMedida();
            return View(MostrarErros(response, produtoModel));
        }

        // GET: Produto/Edit/5
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = _service.GetOneById(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = _selectListService.SelectCategoriaModel("Id", "Descricao");
            ViewData["UnidaDeMedida"] = _selectListService.SelectUnidadeMedida();
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoModel produtoModel)
        {
            Autenticar();
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            var response = _service.PutProduct(produtoModel);
            if (!response.IsValid)
                return View(MostrarErros(response, produtoModel));

            ViewData["IdCategoria"] = _selectListService.SelectCategoriaModel("Id", "Descricao");
            ViewData["UnidaDeMedida"] = _selectListService.SelectUnidadeMedida();
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Delete/5
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var produto = _service.GetOneById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            var categoriaModel = _service.Delet(id);
            if (categoriaModel)
                return RedirectToAction("Index", "Produto");

            ViewBag.ErroExcluir = "Não foi possivel excluir esse Produto!";
            return View(_service.GetOneById(id));
        }
    }
}
