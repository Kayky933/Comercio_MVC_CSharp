using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Mercado.MVC.Validation.ValidateModels.BusinessValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mercado.MVC.Repository
{
    public class EntregaFornecedorService : IEntregaFornecedorService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEntregaFornecedorRepository _entrega;
        public EntregaFornecedorService(IProdutoRepository produtoRepository, IFornecedorRepository fornecedorRepository, IEntregaFornecedorRepository entrega)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _entrega = entrega;
        }
        public ValidationResult Create(EntregaFornecedorModel model)
        {
            var validation = new EntregaFornecedorValidation().Validate(model);
            var businessValidation = new EntregaFornecedorBusinessValidation(_fornecedorRepository, _produtoRepository).Validate(model);

            if (!validation.IsValid)
                return validation;

            if (!businessValidation.IsValid)
                return businessValidation;

            var produto = _produtoRepository.GetOneById(model.Id_Produto);

            produto.Quantidade_Produto += model.Quantidade;
            _produtoRepository.Update(produto);

            _entrega.Create(model);
            return validation;
        }

        public IEnumerable<EntregaFornecedorModel> GetAll(Guid? id)
        {
            return _entrega.GetAll(id);
        }

        public DbSet<EntregaFornecedorModel> GetContext()
        {
            return _entrega.GetContext();
        }

        public EntregaFornecedorModel GetOneById(Guid? id)
        {
            return _entrega.GetOneById(id);
        }
    }
}
