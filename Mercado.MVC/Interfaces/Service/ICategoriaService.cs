using FluentValidation.Results;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        public ValidationResult CreateCategory(CategoriaModel categoria);
        public ValidationResult PutCategory(CategoriaModel categoria);
        public DbSet<CategoriaModel> GetContext();
    }
}
