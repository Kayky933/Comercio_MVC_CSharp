using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using System.Collections.Generic;

namespace Mercado.MVC.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _prodRepository;
        public VendaService(IVendaRepository repository, IProdutoRepository prodRepository)
        {
            _repository = repository;
            _prodRepository = prodRepository;
        }
        public ValidationResult CreateVenda(VendaModel categoria)
        {
            var validation = new VendaValidation(_prodRepository, _repository,categoria.IdProduto).Validate(categoria);
            if (!validation.IsValid)
                return validation;

            var prod = _prodRepository.GetOneById(categoria.IdProduto);
           prod.QuantidadeProduto -= categoria.Quantidade;
            _prodRepository.Update(prod);
            categoria.ValorVenda = prod.PrecoUnidade * categoria.Quantidade;
            _repository.Create(categoria);
            return validation;
        }

        public bool Delet(int id)
        {
            var venda = _repository.GetOneById(id);
            if (venda == null)
                return false;

            _repository.Delete(venda);
            return true;
        }

        public IEnumerable<VendaModel> GetAll()
        {
            return _repository.GetAll();
        }

        public VendaModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
        }
    }
}
