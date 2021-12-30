using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public IEnumerable<ProdutoModel> GetAll()
        {
            return _context.ProdutoModel.ToList();
        }

        public ProdutoModel GetOneById(int? id)
        {
            return _context.ProdutoModel.Where(x => x.Id == id).FirstOrDefault();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }
    }
}
