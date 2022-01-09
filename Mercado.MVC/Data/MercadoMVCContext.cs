using Microsoft.EntityFrameworkCore;
using Mercado.MVC.Models;

namespace Mercado.MVC.Data
{
    public class MercadoMVCContext : DbContext
    {
        public MercadoMVCContext(DbContextOptions<MercadoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Mercado.MVC.Models.CategoriaModel> CategoriaModel { get; set; }

        public DbSet<Mercado.MVC.Models.ProdutoModel> ProdutoModel { get; set; }

        public DbSet<Mercado.MVC.Models.VendaModel> VendaModel { get; set; }

        public DbSet<Mercado.MVC.Models.ClienteModel> ClienteModel { get; set; }
    }
}
