using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mercado.MVC.Service
{
    public class CaregoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CaregoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult CreateCategory(CategoriaModel categoria)
        {
            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                return validation;

            _repository.Create(categoria);
            return validation;
        }

        public bool Delet(int id)
        {
            var categoria = _repository.GetOneById(id);
            if (categoria == null)
                return false;
            _repository.Delete(categoria);
            return true;
        }

        public IEnumerable<CategoriaModel> GetAll()
        {
            return _repository.GetAll();
        }

        public DbSet<CategoriaModel> GetContext()
        {
            return _repository.GetContext();
        }

        public CategoriaModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
        }

        public ValidationResult PutCategory(CategoriaModel categoria)
        {
            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                return validation;

            _repository.Update(categoria);
            return validation;

        }
    }
}
