using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MercadoMVCContext _context;

        public ClienteRepository(MercadoMVCContext context)
        {
            _context = context;
        }
        public void Create(ClienteModel entity)
        {
            _context.ClienteModel.Add(entity);
            SaveChangesDb();
        }

        public void Delete(ClienteModel entity)
        {
            _context.ClienteModel.Remove(entity);
            SaveChangesDb();
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _context.ClienteModel.ToList();
        }

        public DbSet<ClienteModel> GetContext()
        {
            return _context.ClienteModel;
        }

        public ClienteModel GetOneById(int? id)
        {
            return _context.ClienteModel.Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

        public void Update(ClienteModel entity)
        {
            _context.ClienteModel.Update(entity).State = EntityState.Modified;
            SaveChangesDb();
        }
    }
}
