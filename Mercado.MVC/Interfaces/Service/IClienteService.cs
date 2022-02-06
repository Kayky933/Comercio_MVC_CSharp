using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IClienteService : IBaseService<ClienteModel>
    {
        public ValidationResult PutClient(ClienteModel cliente);
        public bool Delet(int id);
    }
}
