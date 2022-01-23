using FluentValidation.Results;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Models;
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
            throw new System.NotImplementedException();
        }

        public bool Delet(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FornecedorModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DbSet<FornecedorModel> GetContext()
        {
            throw new System.NotImplementedException();
        }

        public FornecedorModel GetOneById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResult PutFornecedor(FornecedorModel cliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
