using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        public ValidationResult PutProduct(ProdutoModel produto);
        public bool Delet(int id);
    }
}
