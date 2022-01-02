using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void SaveChangesDb();
        public T GetOneById(int? id);
        public IEnumerable<T> GetAll();
    }
}
