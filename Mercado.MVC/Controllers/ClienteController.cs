using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercado.MVC.Controllers
{
    [Authorize]
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
            Autenticar();
            return View(_service.GetAll(ViewBag.usuarioId));
        }

        // GET: Cliente/Details/5
        public IActionResult Details(Guid? id)
        {
            Autenticar();
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
            Autenticar();
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
            Autenticar();
            var response = _service.Create(clienteModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Cliente");

            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, clienteModel));
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(Guid? id)
        {
            Autenticar();
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
        public IActionResult Edit(Guid id, ClienteModel clienteModel)
        {
            Autenticar();
            var response = _service.PutClient(clienteModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Cliente");

            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, clienteModel));
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(Guid? id)
        {
            Autenticar();
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
        public IActionResult DeleteConfirmed(Guid id)
        {
            Autenticar();
            var response = _service.Delet(id);
            if (response)
                return RedirectToAction("Index", "Cliente");

            ViewBag.ErroExcluir = "Não foi possível excluir esse cliete, verifique se ele tem vendas pendentes!";
            return View("Delete", "Cliente");
        }
    }
}
