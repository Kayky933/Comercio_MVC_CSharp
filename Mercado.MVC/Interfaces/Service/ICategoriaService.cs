using FluentValidation.Results;
using Mercado.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        Task<ValidationResult> CreateCategory(CategoriaModel categoria);
        Task<ValidationResult> PutCategory(CategoriaModel categoria);
        public DbSet<CategoriaModel> GetContext();
    }
}
