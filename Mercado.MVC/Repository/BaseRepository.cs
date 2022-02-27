using Mercado.MVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly MercadoMVCContext _context;

        public BaseRepository(MercadoMVCContext context)
        {
            _context = context;
        }
        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveDb();
        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity).State = EntityState.Modified;
            SaveDb();
        }
        public virtual IEnumerable<T> GetAll(Guid? id)
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetOneById(Guid? id)
        {
            return _context.Set<T>().FirstOrDefault();
        }
        public virtual void SaveDb()
        {
            _context.SaveChanges();
        }

        public virtual DbSet<T> GetContext()
        {
            return _context.Set<T>();
        }
    }
}

