using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Controllers
{
    public class VendaController : ControllerPai
    {
        private readonly MercadoMVCContext _context;
        private readonly IVendaService _service;

        public VendaController(IVendaService service, MercadoMVCContext context)
        {
            _context = context;
            _service = service;
        }

        // GET: Venda
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Venda/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = _service.GetOneById(id);
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
        public IActionResult Create( VendaModel vendaModel)
        {
            var response = _service.CreateVenda(vendaModel);            
            if (response.IsValid )
                return RedirectToAction("Index", "Venda");
            ViewData["IdProduto"] = new SelectList(_context.ProdutoModel, "Id", "Descricao");

            return View(MostrarErros(response, vendaModel));
        }


        // GET: Venda/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaModel = _service.GetOneById(id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vendaModel = _service.Delet(id);
            if (vendaModel)
                return RedirectToAction("Index", "Venda");

            ViewBag.ErroExcluir = "Não foi possivel excluir essa Venda!";
            return View(_service.GetOneById(id));
        }

        private bool VendaModelExists(int id)
        {
            return _context.VendaModel.Any(e => e.Id == id);
        }
    }
}
