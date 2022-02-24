using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void SaveDb();
        public T GetOneById(int? id);
        public IEnumerable<T> GetAll(int? id);
        public DbSet<T> GetContext();
    }
}
