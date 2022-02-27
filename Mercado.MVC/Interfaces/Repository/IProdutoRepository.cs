using Mercado.MVC.Models;
namespace Mercado.MVC.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseRepository<ProdutoModel>
    {
        void Update(ProdutoModel entity);
        void Delete(ProdutoModel entity);
    }
}
