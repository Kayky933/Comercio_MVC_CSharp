using Mercado.MVC.Data;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class VendaController : Controller
    {
        private readonly MercadoMVCContext _context;

        public VendaController(MercadoMVCContext context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var mercadoMVCContext = _context.VendaModel.Include(v => v.Produto);
            return View(await mercadoMVCContext.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.VendaModel
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,IdProduto")] VendaModel vendaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", vendaModel.IdProduto);
            return View(vendaModel);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.VendaModel.FindAsync(id);
            if (vendaModel == null)
            {
                return NotFound();
            }
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", vendaModel.IdProduto);
            return View(vendaModel);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,IdProduto")] VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaModelExists(vendaModel.Id))
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
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao", vendaModel.IdProduto);
            return View(vendaModel);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.VendaModel
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendaModel = await _context.VendaModel.FindAsync(id);
            _context.VendaModel.Remove(vendaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaModelExists(int id)
        {
            return _context.VendaModel.Any(e => e.Id == id);
        }
    }
}
