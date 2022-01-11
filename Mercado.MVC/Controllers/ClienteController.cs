using Mercado.MVC.Data;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MercadoMVCContext _context;

        public ClienteController(MercadoMVCContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteModel.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["Sexo"] = new SelectList(Enum.GetValues(typeof(SexoEnum)));
            ViewData["Uf"] = new SelectList(Enum.GetValues(typeof(UnidadeFederalEnum)));
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(SexoEnum)));
            ViewData["Uf"] = new SelectList(Enum.GetValues(typeof(UnidadeFederalEnum)));
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(SexoEnum)));
            ViewData["Uf"] = new SelectList(Enum.GetValues(typeof(UnidadeFederalEnum)));
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Razao_Social,Nome_Fantasia,Data_Nascimento,RG,CPF,Bairro,Endereco,Telefone,Celular,Whatsapp,Email,Sexo")] ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidaDeMedida"] = new SelectList(Enum.GetValues(typeof(SexoEnum)));
            ViewData["Uf"] = new SelectList(Enum.GetValues(typeof(UnidadeFederalEnum)));
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteModel = await _context.ClienteModel.FindAsync(id);
            _context.ClienteModel.Remove(clienteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
            return _context.ClienteModel.Any(e => e.Id == id);
        }
    }
}
