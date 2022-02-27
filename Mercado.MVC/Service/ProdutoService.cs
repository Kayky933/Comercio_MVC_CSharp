using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Mercado.MVC.Validation.ValidateModels.BusinessValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mercado.MVC.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly ICategoriaRepository _categoryRepository;
        public ProdutoService(IProdutoRepository repository, ICategoriaRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }
        public ValidationResult Create(ProdutoModel model)
        {
            var validation = new ProdutoValidation(false).Validate(model);
            var validationBusiness = new ProdutoBusinessValidation(_categoryRepository).Validate(model);
            if (!validation.IsValid)
                return validation;

            if (!validationBusiness.IsValid)
                return validationBusiness;

            _repository.Create(model);
            return validation;
        }

        public bool Delet(Guid id)
        {
            var produto = _repository.GetOneById(id);
            if (produto == null)
                return false;
            _repository.Delete(produto);
            return true;
        }

        public IEnumerable<ProdutoModel> GetAll(Guid? id)
        {
            return _repository.GetAll(id);
        }

        public DbSet<ProdutoModel> GetContext()
        {
            return _repository.GetContext();
        }

        public ProdutoModel GetOneById(Guid? id)
        {
            var produto = _repository.GetOneById(id);
            if (produto == null)
                return null;

            return produto;
        }

        public ValidationResult PutProduct(ProdutoModel model)
        {
            var validation = new ProdutoValidation(true).Validate(model);
            var validationBusiness = new ProdutoBusinessValidation(_categoryRepository).Validate(model);
            if (!validation.IsValid)
                return validation;

            if (!validationBusiness.IsValid)
                return validationBusiness;

            _repository.Update(model);
            return validation;
        }
    }
}
