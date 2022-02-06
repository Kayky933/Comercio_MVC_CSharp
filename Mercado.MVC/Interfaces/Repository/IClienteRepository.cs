using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IClienteRepository : IBaseRepository<ClienteModel>
    {
        void Update(ClienteModel entity);
        void Delete(ClienteModel entity);
    }
}
