using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;

namespace Mercado.MVC.Repository
{
    public class VendaRepository : BaseRepository<VendaModel>, IVendaRepository
    {
        public VendaRepository(MercadoMVCContext context) : base(context)
        {
        }

    }
}
