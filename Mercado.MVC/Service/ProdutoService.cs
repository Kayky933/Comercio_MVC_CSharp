using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
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
        public ValidationResult CreateProduct(ProdutoModel produto)
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

        public ProdutoModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
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
