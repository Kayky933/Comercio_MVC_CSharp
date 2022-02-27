using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        public FornecedorRepository(MercadoMVCContext context) : base(context)
        {
        }
        public override IEnumerable<FornecedorModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id).ToList();
        }
        public override FornecedorModel GetOneById(Guid? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
        public void Delete(FornecedorModel entity)
        {
            GetContext().Remove(entity);
            SaveDb();
        }
    }
}
