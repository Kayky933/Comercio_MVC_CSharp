using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mercado.MVC.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult Create(FornecedorModel model)
        {
            var validation = new FornecedorValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            _repository.Create(model);
            return validation;
        }

        public bool Delet(int id)
        {
            var fornecedor = _repository.GetOneById(id);
            if (fornecedor == null)
                return false;

            _repository.Delete(fornecedor);
            return true;
        }

        public IEnumerable<FornecedorModel> GetAll()
        {
            return _repository.GetAll();
        }

        public DbSet<FornecedorModel> GetContext()
        {
            return _repository.GetContext();
        }

        public FornecedorModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
        }

        public ValidationResult PutFornecedor(FornecedorModel model)
        {
            var validation = new FornecedorValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            _repository.Update(model);
            return validation;
        }
    }
}
