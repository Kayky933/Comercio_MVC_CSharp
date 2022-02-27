using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class ClienteRepository : BaseRepository<ClienteModel>, IClienteRepository
    {

        public ClienteRepository(MercadoMVCContext context) : base(context)
        {
        }
        public override IEnumerable<ClienteModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id).ToList();
        }
        public override ClienteModel GetOneById(Guid? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
        public void Delete(ClienteModel entity)
        {
            GetContext().Remove(entity);
            SaveDb();
        }
    }
}
