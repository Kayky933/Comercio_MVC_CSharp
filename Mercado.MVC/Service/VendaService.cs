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
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _prodRepository;
        public VendaService(IVendaRepository repository, IProdutoRepository prodRepository)
        {
            _repository = repository;
            _prodRepository = prodRepository;
        }
        public ValidationResult Create(VendaModel model)
        {
            var prod = _prodRepository.GetOneById(model.IdProduto);

            model.ValorVenda = prod.PrecoUnidade * Convert.ToDecimal(model.Quantidade);

            var validation = new VendaValidation().Validate(model);
            var businessValidation = new VendaBusinessValidation(_prodRepository, model.IdProduto).Validate(model);

            if (!validation.IsValid)
                return validation;

            if (!businessValidation.IsValid)
                return businessValidation;

            prod.QuantidadeProduto -= model.Quantidade;

            _prodRepository.Update(prod);
            
            _repository.Create(model);
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

        public DbSet<VendaModel> GetContext()
        {
            return _repository.GetContext();
        }

        public VendaModel GetOneById(int? id)
        {
            var venda = _repository.GetOneById(id);
            if (venda == null)
                return null;

            return venda;
        }
    }
}
