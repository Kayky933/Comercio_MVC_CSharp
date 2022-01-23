using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        public FornecedorRepository(MercadoMVCContext context) : base(context)
        {
        }
        public override FornecedorModel GetOneById(int? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
