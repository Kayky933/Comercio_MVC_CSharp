using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        public ValidationResult PutCategory(CategoriaModel categoria);
    }
}
