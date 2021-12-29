using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class CategoriaController : ControllerPai
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _service.GetOneById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaModel categoriaModel)
        {
            var response = await _service.CreateCategory(categoriaModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Categoria");

            return View(MostrarErros(response, categoriaModel));
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _service.GetOneById(id);
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
        public async Task<IActionResult> Edit(int id, CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.Id)
            {
                return NotFound();
            }

            var response = await _service.PutCategory(categoriaModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Categoria");

            return View(MostrarErros(response, categoriaModel));
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _service.GetOneById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaModel = await _service.Delet(id);
            if (categoriaModel)
                return RedirectToAction("Index", "Categoria");

            ViewBag.ErroExcluir = "Não foi possivel excluir essa Categoria, verifique se ha produtos relacionados a ela";
            return View(_service.GetOneById(id));
        }
    }
}
