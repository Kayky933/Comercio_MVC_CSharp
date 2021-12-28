using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOneById(int? id);
        Task<bool> Delet(int id);
    }
}
