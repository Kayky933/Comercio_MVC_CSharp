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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult Create(ClienteModel model)
        {
            var validation = new ClienteValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            _repository.Create(model);
            return validation;
        }

        public bool Delet(Guid id)
        {
            var cliente = _repository.GetOneById(id);
            if (cliente == null)
                return false;

            _repository.Delete(cliente);
            return true;
        }

        public IEnumerable<ClienteModel> GetAll(Guid? id)
        {
            return _repository.GetAll(id);
        }

        public DbSet<ClienteModel> GetContext()
        {
            return _repository.GetContext();
        }

        public ClienteModel GetOneById(Guid? id)
        {
            var cliente = _repository.GetOneById(id);
            if (cliente == null)
                return null;

            return cliente;
        }

        public ValidationResult PutClient(ClienteModel model)
        {
            var validation = new ClienteValidation().Validate(model);
            if (!validation.IsValid)
                return validation;
            _repository.Update(model);
            return validation;
        }
    }
}
