using FluentValidation.Results;
using Mercado.MVC.Models;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        Task<ValidationResult> CreateProduct(ProdutoModel produto);
        Task<ValidationResult> PutProduct(ProdutoModel produto);
    }
}
