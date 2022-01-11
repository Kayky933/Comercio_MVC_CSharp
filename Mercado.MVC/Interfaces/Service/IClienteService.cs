using FluentValidation.Results;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IClienteService:IBaseService<ClienteModel>
    {
        public ValidationResult CreateClient(ClienteModel cliente);
        public ValidationResult PutClient(ClienteModel cliente);
    }
}
