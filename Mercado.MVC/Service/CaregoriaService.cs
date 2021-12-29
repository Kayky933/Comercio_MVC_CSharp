using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.MVC.Service
{
    public class CaregoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CaregoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> CreateCategory(CategoriaModel categoria)
        {
            var validation = await new CategoriaValidation().ValidateAsync(categoria);
            if (!validation.IsValid)
                return validation;

            _repository.Create(categoria);
            return validation;
        }

        public async Task<bool> Delet(int id)
        {
            var categoria = await _repository.GetOneById(id);
            if (categoria == null)
                return false;
            _repository.Delete(categoria);
            return true;
        }

        public async Task<IEnumerable<CategoriaModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public DbSet<CategoriaModel> GetContext()
        {
            return _repository.GetContext();
        }

        public async Task<CategoriaModel> GetOneById(int? id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<ValidationResult> PutCategory(CategoriaModel categoria)
        {
            var validation = await new CategoriaValidation().ValidateAsync(categoria);
            if (!validation.IsValid)
                return validation;

            _repository.Update(categoria);
            return validation;

        }
    }
}
