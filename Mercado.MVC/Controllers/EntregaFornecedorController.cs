using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    [Authorize]
    public class EntregaFornecedorController : ControllerPai
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
            Autenticar();
            return View(_service.GetAll(ViewBag.usuarioId));
        }

        // GET: EntregaFornecedor/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
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
            Autenticar();
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
            Autenticar();
            var response = _service.Create(entregaFornecedorModel);
            if (response.IsValid)
                return RedirectToAction("Index", "EntregaFornecedor");

            ViewData["IdFornecedor"] = _selectListService.SelectFornecedorModel("Id", "Razao_Social");
            ViewData["IdProduto"] = _selectListService.SelectProdutoModel("Id", "Descricao");
            return View(entregaFornecedorModel);
        }

    }
}
