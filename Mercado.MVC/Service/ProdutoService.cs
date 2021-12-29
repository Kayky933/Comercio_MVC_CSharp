using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ValidationResult> CreateProduct(ProdutoModel produto)
        {
            var validation = await new ProdutoValidation(_categoryRepository, false).ValidateAsync(produto);
            if (!validation.IsValid)
                return validation;

            _repository.Create(produto);
            return validation;
        }

        public async Task<bool> Delet(int id)
        {
            var produto = await _repository.GetOneById(id);
            if (produto == null)
                return false;
            _repository.Delete(produto);
            return true;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ProdutoModel> GetOneById(int? id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<ValidationResult> PutProduct(ProdutoModel produto)
        {
            var validation = await new ProdutoValidation(_categoryRepository, true).ValidateAsync(produto);
            if (!validation.IsValid)
                return validation;

            _repository.Update(produto);
            return validation;
        }
    }
}
