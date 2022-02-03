using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class ClienteRepository : BaseRepository<ClienteModel>, IClienteRepository
    {

        public ClienteRepository(MercadoMVCContext context) : base(context)
        {
        }

        public override ClienteModel GetOneById(int? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
