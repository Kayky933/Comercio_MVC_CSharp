using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IFornecedorService : IBaseService<FornecedorModel>
    {
        public ValidationResult PutFornecedor(FornecedorModel model);
        public bool Delet(int id);
    }
}
