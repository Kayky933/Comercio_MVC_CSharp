using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseRepository<CategoriaModel>
    {
        void Update(CategoriaModel entity);
    }
}
