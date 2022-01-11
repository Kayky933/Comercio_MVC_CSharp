using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            entity.DataAddCategoria = DateTime.UtcNow;
            _context.CategoriaModel.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }


        public IEnumerable<CategoriaModel> GetAll()
        {
            return _context.CategoriaModel.ToList();
        }

        public CategoriaModel GetOneById(int? id)
        {
            return _context.CategoriaModel.Where(x => x.Id == id).FirstOrDefault();
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
