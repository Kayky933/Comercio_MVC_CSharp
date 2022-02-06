using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    public class EntregaFornecedorController : Controller
    {
        private readonly IEntregaFornecedorService _service;
        private readonly ISelectListService _selectListService;

        public EntregaFornecedorController(IEntregaFornecedorService service, ISelectListService selectListService)
        {
            _service = service;
            _selectListService = selectListService;
        }

        // GET: EntregaFornecedor
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: EntregaFornecedor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaFornecedorModel = _service.GetOneById(id);
            if (entregaFornecedorModel == null)
            {
                return NotFound();
            }

            return View(entregaFornecedorModel);
        }

        // GET: EntregaFornecedor/Create
        public IActionResult Create()
        {
            ViewData["IdFornecedor"] = _selectListService.SelectFornecedorModel("Id", "Razao_Social");
            ViewData["IdProduto"] = _selectListService.SelectProdutoModel("Id", "Descricao");
            return View();
        }

        // POST: EntregaFornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EntregaFornecedorModel entregaFornecedorModel)
        {
            var response = _service.Create(entregaFornecedorModel);
            if (response.IsValid)
                return RedirectToAction("Index", "EntregaFornecedor");

            ViewData["IdFornecedor"] = _selectListService.SelectFornecedorModel("Id", "Razao_Social");
            ViewData["IdProduto"] = _selectListService.SelectProdutoModel("Id", "Descricao");
            return View(entregaFornecedorModel);
        }

    }
}
