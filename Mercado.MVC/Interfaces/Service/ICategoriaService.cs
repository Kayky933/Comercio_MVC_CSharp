using FluentValidation.Results;
using Mercado.MVC.Models;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        Task<ValidationResult> CreateCategory(CategoriaModel produto);
        Task<ValidationResult> PutCategory(CategoriaModel produto);
    }
}
