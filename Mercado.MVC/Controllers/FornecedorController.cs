using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    public class FornecedorController : ControllerPai
    {
        private readonly IFornecedorService _service;
        private readonly ISelectListService _selectListService;

        public FornecedorController(IFornecedorService service, ISelectListService selectListService)
        {
            _service = service;
            _selectListService = selectListService;
        }

        // GET: Fornecedor
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Fornecedor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = _service.GetOneById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorModel fornecedorModel)
        {
            var response = _service.Create(fornecedorModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Fornecedor");
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, fornecedorModel));
        }

        // GET: Fornecedor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = _service.GetOneById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(fornecedorModel);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.Id)
            {
                return NotFound();
            }

            var response = _service.PutFornecedor(fornecedorModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Fornecedor");
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            ViewData["Uf"] = _selectListService.SelecListUF();
            return View(MostrarErros(response, fornecedorModel));
        }

        // GET: Fornecedor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = _service.GetOneById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var response = _service.Delet(id);
            if (response)
                return RedirectToAction("Index", "Fornecedor");

            ViewBag.ErroExcluir = "Não foi possível excluir esse Fornecedor, verifique se ele tem entregas pendentes!";
            return View("Delete", "Fornecedor");
        }
    }
}
