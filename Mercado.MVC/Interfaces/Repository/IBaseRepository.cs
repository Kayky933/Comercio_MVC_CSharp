using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void SaveDb();
        public T GetOneById(Guid? id);
        public IEnumerable<T> GetAll(Guid? id);
        public DbSet<T> GetContext();
    }
}
