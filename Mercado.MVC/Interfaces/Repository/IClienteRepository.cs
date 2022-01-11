using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IClienteRepository:IBaseRepository<ClienteModel>
    {
        void Update(ClienteModel entity);
    }
}
