using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.MVC.Data
{
    public class MercadoMVCContext : DbContext
    {
        public MercadoMVCContext(DbContextOptions<MercadoMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuração DbDeletCascade EntregaFornecedorModel
            //restringe a esclusão de FornecedorModel caso tenha alguma EntregaFornecedorModel vinculado
            modelBuilder.Entity<EntregaFornecedorModel>()
                .HasOne(p => p.Fornecedor)
                .WithMany(c => c.Entregas)
                .HasForeignKey(p => p.Id_Fornecedor)
                .OnDelete(DeleteBehavior.Restrict);

            //restringe a esclusão de ProdutoModel caso tenha alguma EntregaFornecedorModel vinculado
            modelBuilder.Entity<EntregaFornecedorModel>()
               .HasOne(p => p.Produto)
               .WithMany(c => c.Entregas)
               .HasForeignKey(p => p.Id_Produto)
               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Configuração DbDeletCascade VendaModel
            //restringe a esclusão de ClienteModel caso tenha alguma VendaModel vinculada
            modelBuilder.Entity<VendaModel>()
               .HasOne(p => p.Cliente)
               .WithMany(c => c.Vendas)
               .HasForeignKey(p => p.Id_Cliente)
               .OnDelete(DeleteBehavior.Restrict);

            //restringe a esclusão de ProdutoModel caso tenha alguma VendaModel vinculada
            modelBuilder.Entity<VendaModel>()
              .HasOne(p => p.Produto)
              .WithMany(c => c.Vendas)
              .HasForeignKey(p => p.Id_Produto)
              .OnDelete(DeleteBehavior.Restrict);

            //restringe a esclusão de ProdutoModel caso tenha alguma VendaModel vinculada
            modelBuilder.Entity<VendaModel>()
             .HasOne(p => p.Produto)
             .WithMany(c => c.Vendas)
             .HasForeignKey(p => p.Id_Produto)
             .OnDelete(DeleteBehavior.Restrict);

            //restringe a esclusão de ClienteModel caso tenha alguma VendaModel vinculada
            modelBuilder.Entity<VendaModel>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Vendas)
            .HasForeignKey(p => p.Id_Cliente)
            .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region  #region Configuração DbDeletCascade ProdutoModel
            //restringe a esclusão de CategoriaModel caso tenha alguma ProtudoModel vinculada
            modelBuilder.Entity<ProdutoModel>()
             .HasOne(p => p.Categoria)
             .WithMany(c => c.Produtos)
             .HasForeignKey(p => p.Id_Categoria)
             .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }

        public DbSet<Mercado.MVC.Models.CategoriaModel> CategoriaModel { get; set; }
        public DbSet<Mercado.MVC.Models.ProdutoModel> ProdutoModel { get; set; }
        public DbSet<Mercado.MVC.Models.VendaModel> VendaModel { get; set; }
        public DbSet<Mercado.MVC.Models.ClienteModel> ClienteModel { get; set; }
        public DbSet<Mercado.MVC.Models.FornecedorModel> FornecedorModel { get; set; }
        public DbSet<Mercado.MVC.Models.EntregaFornecedorModel> EntregaFornecedorModel { get; set; }
        public DbSet<Mercado.MVC.Models.UsuarioModel> UsuarioModel { get; set; }
    }
}
