using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    public class ClienteController : ControllerPai
    {
        private readonly IClienteService _service;
        private readonly ISelectListService _selectListService;

        public ClienteController(IClienteService service, ISelectListService selectListService)
        {
            _service = service;
            _selectListService = selectListService;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Cliente/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = _service.GetOneById(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteModel clienteModel)
        {
            var response = _service.Create(clienteModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Cliente");

            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, clienteModel));
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = _service.GetOneById(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteModel clienteModel)
        {
            var response = _service.PutClient(clienteModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Cliente");

            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, clienteModel));
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = _service.GetOneById(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var response = _service.Delet(id);
            if (response)
                return RedirectToAction("Index", "Cliente");

            ViewBag.ErroExcluir = "Não foi possível excluir esse cliete, verifique se ele tem vendas pendentes!";
            return View("Delete", "Cliente");
        }
    }
}
