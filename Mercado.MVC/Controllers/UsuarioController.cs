using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class UsuarioController : ControllerPai
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        // GET: Usuario
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_service.GetAll(ViewBag.usuarioId));
        }

        // GET: Usuario/Details/5
        [Authorize]
        public IActionResult Details(Guid? id)
        {
            Autenticar();
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
            Autenticar();
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioModel usuarioModel)
        {
            Autenticar();
            var response = _service.Create(usuarioModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Home");

            return View(MostrarErros(response, usuarioModel));
        }

        // GET: Usuario/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            Autenticar();
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

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, UsuarioModel usuarioModel)
        {
            Autenticar();
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            var response = _service.PutEdicao(id, usuarioModel);
            if (response.IsValid)
                return RedirectToAction("Index", "Usuario");
            return View(MostrarErros(response, usuarioModel));
        }

        // GET: Usuario/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            Autenticar();
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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Autenticar();
            var excluir = _service.Delet(id);
            if (excluir)
                return NoContent();
            return BadRequest();
        }

        // GET
        public IActionResult Login()
        {
            Autenticar();
            return View();
        }

        //POST
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UsuarioModel usuario)
        {
            Autenticar();
            var res = _service.PostLogin(usuario);
            if (res.GetType() == typeof(ClaimsPrincipal))
            {
                HttpContext.SignInAsync((ClaimsPrincipal)res);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErroLogin = "Email ou senha incorretos!";
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            Autenticar();
            return View();
        }

        //POST
        [Authorize]
        [HttpPost, ActionName("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmado()
        {
            Autenticar();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
