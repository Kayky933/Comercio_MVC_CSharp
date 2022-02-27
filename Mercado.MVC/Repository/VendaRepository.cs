using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class VendaRepository : BaseRepository<VendaModel>, IVendaRepository
    {
        public VendaRepository(MercadoMVCContext context) : base(context)
        {
        }

        public override IEnumerable<VendaModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id).ToList();
        }
    }
}
