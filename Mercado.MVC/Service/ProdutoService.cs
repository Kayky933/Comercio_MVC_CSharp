using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
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
        public ValidationResult Create(ProdutoModel produto)
        {
            var validation = new ProdutoValidation(_categoryRepository, false).Validate(produto);
            if (!validation.IsValid)
                return validation;

            _repository.Create(produto);
            return validation;
        }

        public bool Delet(int id)
        {
            var produto = _repository.GetOneById(id);
            if (produto == null)
                return false;
            _repository.Delete(produto);
            return true;
        }

        public IEnumerable<ProdutoModel> GetAll()
        {
            return _repository.GetAll();
        }

        public DbSet<ProdutoModel> GetContext()
        {
            return _repository.GetContext();
        }

        public ProdutoModel GetOneById(int? id)
        {
            var produto = _repository.GetOneById(id);
            if (produto == null)
                return null;

            return produto;
        }

        public ValidationResult PutProduct(ProdutoModel produto)
        {
            var validation = new ProdutoValidation(_categoryRepository, true).Validate(produto);
            if (!validation.IsValid)
                return validation;

            _repository.Update(produto);
            return validation;
        }
    }
}
