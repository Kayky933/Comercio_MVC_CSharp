using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
using System;
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
        public ValidationResult Create(CategoriaModel model)
        {
            var validation = new CategoriaValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            _repository.Create(model);
            return validation;
        }

        public bool Delet(Guid id)
        {
            var categoria = _repository.GetOneById(id);
            if (categoria == null)
                return false;
            _repository.Delete(categoria);
            return true;
        }

        public IEnumerable<CategoriaModel> GetAll(Guid? id)
        {
            return _repository.GetAll(id);
        }

        public DbSet<CategoriaModel> GetContext()
        {
            return _repository.GetContext();
        }

        public CategoriaModel GetOneById(Guid? id)
        {
            var categoria = _repository.GetOneById(id);
            if (categoria == null)
                return null;

            return categoria;
        }

        public ValidationResult PutCategory(CategoriaModel model)
        {
            var validation = new CategoriaValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            _repository.Update(model);
            return validation;

        }
    }
}
