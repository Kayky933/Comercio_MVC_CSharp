using FluentValidation.Results;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IClienteService : IBaseService<ClienteModel>
    {
        public ValidationResult PutClient(ClienteModel cliente);
        public bool Delet(Guid id);
    }
}
