using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class EntregaFornecedorRepository : BaseRepository<EntregaFornecedorModel>, IEntregaFornecedorRepository
    {
        public EntregaFornecedorRepository(MercadoMVCContext context) : base(context)
        {
        }

        public override IEnumerable<EntregaFornecedorModel> GetAll(int? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id)
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto).ToList();
        }
        public override EntregaFornecedorModel GetOneById(int? id)
        {
            return GetContext()
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto).FirstOrDefault(x => x.Id == id);
        }
    }
}
