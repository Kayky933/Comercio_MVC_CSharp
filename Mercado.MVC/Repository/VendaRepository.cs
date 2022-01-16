using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly MercadoMVCContext _context;
        public VendaRepository(MercadoMVCContext context)
        {
            _context = context;
        }
        public void Create(VendaModel entity)
        {
            _context.VendaModel.Add(entity);
            SaveDb();
        }

        public void Delete(VendaModel entity)
        {
            _context.VendaModel.Remove(entity);
            SaveDb();

        }

        public IEnumerable<VendaModel> GetAll()
        {
            return _context.VendaModel
                .Include(x => x.Produto).ToList();
        }

        public DbSet<VendaModel> GetContext()
        {
            return _context.Set<VendaModel>();
        }

        public VendaModel GetOneById(int? id)
        {
            return _context.VendaModel.Where(x => x.Id == id)
                .Include(x => x.Produto).FirstOrDefault();
        }

        public void SaveDb()
        {
            _context.SaveChanges();
        }


    }
}
