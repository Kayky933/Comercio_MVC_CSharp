using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IFornecedorRepository : IBaseRepository<FornecedorModel>
    {
        public void Update(FornecedorModel fornecedorModel);
    }
}
