using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.MVC.Controllers
{
    public class UsuarioController : ControllerPai
    {
        private readonly IUsuarioService _service;
        private readonly ISelectListService _selectListService;

        public UsuarioController(IUsuarioService service, ISelectListService selectListService)
        {
            _service = service;
            _selectListService = selectListService;
        }

        // GET: Usuario
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = _service.GetOneById(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioModel usuarioModel)
        {
            var response = _service.Create(usuarioModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Usuario");

            ViewData["Sexo"] = _selectListService.SelectListSexo();
            return View(MostrarErros(response, usuarioModel));
        }

        // GET: Usuario/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = _service.GetOneById(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            var response = _service.PutEdicao(id, usuarioModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Usuario");
            ViewData["Sexo"] = _selectListService.SelectListSexo();
            return View(MostrarErros(response, usuarioModel));
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = _service.GetOneById(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var excluir = _service.PostExclusao(id);
            if (excluir)
                return NoContent();
            return BadRequest();
        }
    }
}
