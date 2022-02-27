using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Mercado.MVC.Repository
{
    public class CategoriaRepository : BaseRepository<CategoriaModel>, ICategoriaRepository
    {

        public CategoriaRepository(MercadoMVCContext context) : base(context)
        {
        }
        public override IEnumerable<CategoriaModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id).ToList();
        }
        public override void Update(CategoriaModel entity)
        {
            entity.DataAddCategoria = DateTime.Now;
            GetContext().Update(entity).State = EntityState.Modified;
            SaveDb();
        }
        public override CategoriaModel GetOneById(Guid? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
        public void Delete(CategoriaModel entity)
        {
            GetContext().Remove(entity);
            SaveDb();
        }
    }
}
