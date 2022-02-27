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
            var prod = _prodRepository.GetOneById(model.Id_Produto);

            model.Valor_Venda = prod.Preco_Unidade * Convert.ToDecimal(model.Quantidade);

            var validation = new VendaValidation().Validate(model);
            var businessValidation = new VendaBusinessValidation(_prodRepository, model.Id_Produto).Validate(model);

            if (!validation.IsValid)
                return validation;

            if (!businessValidation.IsValid)
                return businessValidation;

            prod.Quantidade_Produto -= model.Quantidade;

            _prodRepository.Update(prod);

            _repository.Create(model);
            return validation;
        }

        public IEnumerable<VendaModel> GetAll(Guid? id)
        {
            return _repository.GetAll(id);
        }

        public DbSet<VendaModel> GetContext()
        {
            return _repository.GetContext();
        }

        public VendaModel GetOneById(Guid? id)
        {
            var venda = _repository.GetOneById(id);
            if (venda == null)
                return null;

            return venda;
        }
    }
}
