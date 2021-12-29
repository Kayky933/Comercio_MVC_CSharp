using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _service;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService service, ICategoriaService categoriaService)
        {
            _service = service;
            _categoriaService = categoriaService;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            //var mercadoMVCContext = _context.ProdutoModel.Include(p => p.Categoria);
            return View(await _service.GetAll());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = await _service.GetOneById(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_categoriaService.GetContext(), "Id", "Descricao");
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(UnidadeMedidaEnum)));
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoModel produtoModel)
        {
            var response = await _service.CreateProduct(produtoModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Produto");

            ViewData["IdCategoria"] = new SelectList(_categoriaService.GetContext(), "Id", "Descricao");
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(UnidadeMedidaEnum)));
            return View(MostrarErros(response, produtoModel));
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = await _service.GetOneById(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(UnidadeMedidaEnum)));
            ViewData["IdCategoria"] = new SelectList(_categoriaService.GetContext(), "Id", "Descricao", produtoModel.IdCategoria);
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            var response = await _service.PutProduct(produtoModel);
            if (!response.IsValid)
                return View(MostrarErros(response, produtoModel));
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(UnidadeMedidaEnum)));
            ViewData["IdCategoria"] = new SelectList(_categoriaService.GetContext(), "Id", "Descricao", produtoModel.IdCategoria);
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _service.GetOneById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaModel = await _service.Delet(id);
            if (categoriaModel)
                return RedirectToAction("Index", "Produto");

            ViewBag.ErroExcluir = "Não foi possivel excluir esse Produto!";
            return View(_service.GetOneById(id));
        }
    }
}
