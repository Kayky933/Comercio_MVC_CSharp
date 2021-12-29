using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MercadoMVCContext _context;

        public ProdutoRepository(MercadoMVCContext context)
        {
            _context = context;
        }

        public void Create(ProdutoModel entity)
        {
            _context.ProdutoModel.Add(entity);
            SaveChangesDb();
        }

        public void Delete(ProdutoModel entity)
        {
            _context.ProdutoModel.Remove(entity);
            SaveChangesDb();
        }

        public void Update(ProdutoModel entity)
        {
            _context.ProdutoModel.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }


        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            return await _context.ProdutoModel.ToListAsync();
        }

        public async Task<ProdutoModel> GetOneById(int? id)
        {
            return await _context.ProdutoModel.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }
    }
}
