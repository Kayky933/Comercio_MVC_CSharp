using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    public class VendaController : ControllerPai
    {
        private readonly IVendaService _service;
        private readonly IProdutoService _serviceProd;
        private readonly IClienteService _serviceClient;
        private readonly ISelectListService _selectListService;

        public VendaController(IVendaService service, IProdutoService serviceProd, IClienteService serviceClient, ISelectListService selectListService)
        {
            _service = service;
            _serviceProd = serviceProd;
            _serviceClient = serviceClient;
            _selectListService = selectListService;
        }

        // GET: Venda
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Venda/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = _service.GetOneById(id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = _selectListService.SelectProdutoModel("Id", "Descricao");
            ViewData["IdCliente"] = _selectListService.SelectClienteModel("Id", "Razao_Social");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendaModel vendaModel)
        {
            var response = _service.Create(vendaModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Venda");
            ViewData["IdProduto"] = _selectListService.SelectProdutoModel("Id", "Descricao");
            ViewData["IdCliente"] = _selectListService.SelectClienteModel("Id", "Razao_Social");
            return View(MostrarErros(response, vendaModel));
        }


        // GET: Venda/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = _service.GetOneById(id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }
    }
}
