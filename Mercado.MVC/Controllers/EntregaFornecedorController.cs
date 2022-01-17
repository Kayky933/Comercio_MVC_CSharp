using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercado.MVC.Data;
using Mercado.MVC.Models;

namespace Mercado.MVC.Controllers
{
    public class EntregaFornecedorController : Controller
    {
        private readonly MercadoMVCContext _context;

        public EntregaFornecedorController(MercadoMVCContext context)
        {
            _context = context;
        }

        // GET: EntregaFornecedor
        public async Task<IActionResult> Index()
        {
            var mercadoMVCContext = _context.EntregaFornecedorModel.Include(e => e.Fornecedor).Include(e => e.Produto);
            return View(await mercadoMVCContext.ToListAsync());
        }

        // GET: EntregaFornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaFornecedorModel = await _context.EntregaFornecedorModel
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregaFornecedorModel == null)
            {
                return NotFound();
            }

            return View(entregaFornecedorModel);
        }

        // GET: EntregaFornecedor/Create
        public IActionResult Create()
        {
            ViewData["IdFornecedor"] = new SelectList(_context.FornecedorModel, "Id", "Bairro");
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao");
            return View();
        }

        // POST: EntregaFornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntregaFornecedorModel entregaFornecedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entregaFornecedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFornecedor"] = new SelectList(_context.FornecedorModel, "Id", "Bairro", entregaFornecedorModel.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", entregaFornecedorModel.IdProduto);
            return View(entregaFornecedorModel);
        }

        // GET: EntregaFornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaFornecedorModel = await _context.EntregaFornecedorModel.FindAsync(id);
            if (entregaFornecedorModel == null)
            {
                return NotFound();
            }
            ViewData["IdFornecedor"] = new SelectList(_context.FornecedorModel, "Id", "Bairro", entregaFornecedorModel.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", entregaFornecedorModel.IdProduto);
            return View(entregaFornecedorModel);
        }

        // POST: EntregaFornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,EntregaFornecedorModel entregaFornecedorModel)
        {
            if (id != entregaFornecedorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregaFornecedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaFornecedorModelExists(entregaFornecedorModel.Id))
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
            ViewData["IdFornecedor"] = new SelectList(_context.FornecedorModel, "Id", "Bairro", entregaFornecedorModel.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", entregaFornecedorModel.IdProduto);
            return View(entregaFornecedorModel);
        }

        // GET: EntregaFornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaFornecedorModel = await _context.EntregaFornecedorModel
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregaFornecedorModel == null)
            {
                return NotFound();
            }

            return View(entregaFornecedorModel);
        }

        // POST: EntregaFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entregaFornecedorModel = await _context.EntregaFornecedorModel.FindAsync(id);
            _context.EntregaFornecedorModel.Remove(entregaFornecedorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaFornecedorModelExists(int id)
        {
            return _context.EntregaFornecedorModel.Any(e => e.Id == id);
        }
    }
}
