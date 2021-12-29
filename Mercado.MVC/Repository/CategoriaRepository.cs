using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MercadoMVCContext _context;

        public CategoriaRepository(MercadoMVCContext context)
        {
            _context = context;
        }
        public void Create(CategoriaModel entity)
        {
            _context.CategoriaModel.Add(entity);
            SaveChangesDb();
        }

        public void Delete(CategoriaModel entity)
        {
            _context.CategoriaModel.Remove(entity);
            SaveChangesDb();
        }

        public void Update(CategoriaModel entity)
        {
            _context.CategoriaModel.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }


        public async Task<IEnumerable<CategoriaModel>> GetAll()
        {
            return await _context.CategoriaModel.ToListAsync();
        }

        public async Task<CategoriaModel> GetOneById(int? id)
        {
            return await _context.CategoriaModel.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

        public DbSet<CategoriaModel> GetContext()
        {
            return _context.Set<CategoriaModel>();
        }
    }
}
