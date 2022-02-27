using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercado.MVC.Controllers
{
    [Authorize]
    public class CategoriaController : ControllerPai
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        // GET: Categoria
        public IActionResult Index()
        {
            Autenticar();
            return View(_service.GetAll(ViewBag.usuarioId));
        }

        // GET: Categoria/Details/5
        public IActionResult Details(Guid? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _service.GetOneById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            Autenticar();
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaModel categoriaModel)
        {
            Autenticar();
            var response = _service.Create(categoriaModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Categoria");
            return View(MostrarErros(response, categoriaModel));
        }

        // GET: Categoria/Edit/5
        public IActionResult Edit(Guid? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _service.GetOneById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CategoriaModel categoriaModel)
        {
            Autenticar();
            if (id != categoriaModel.Id)
            {
                return NotFound();
            }

            var response = _service.PutCategory(categoriaModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Categoria");

            return View(MostrarErros(response, categoriaModel));
        }

        // GET: Categoria/Delete/5
        public IActionResult Delete(Guid? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _service.GetOneById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Autenticar();
            var categoriaModel = _service.Delet(id);
            if (categoriaModel)
                return RedirectToAction("Index", "Categoria");

            ViewBag.ErroExcluir = "Não foi possivel excluir essa Categoria, verifique se ha produtos relacionados a ela";
            return View(_service.GetOneById(id));
        }
    }
}
