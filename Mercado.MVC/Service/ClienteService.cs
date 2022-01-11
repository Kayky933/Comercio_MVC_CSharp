using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.MVC.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult CreateClient(ClienteModel cliente)
        {
            var validation = new ClienteValidation().Validate(cliente);
            if (!validation.IsValid)
                return validation;

            _repository.Create(cliente);
            return validation;
        }

        public bool Delet(int id)
        {
            var cliente = _repository.GetOneById(id);
            if (cliente == null)
                return false;

            _repository.Delete(cliente);
            return true;
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public DbSet<ClienteModel> GetContext()
        {
            return _repository.GetContext();
        }

        public ClienteModel GetOneById(int? id)
        {
            var cliente =  _repository.GetOneById(id);
            if (cliente == null)
                return null;

            return cliente;
        }

        public ValidationResult PutClient(ClienteModel cliente)
        {
            var validation = new ClienteValidation().Validate(cliente);
            if (!validation.IsValid)
                return validation;

            return validation;
        }
    }
}
