using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseRepository<CategoriaModel>
    {

        void Update(CategoriaModel entity);       
    }
}
