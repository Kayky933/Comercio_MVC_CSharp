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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult Create(UsuarioModel model)
        {
            var validation = new UsuarioValidation().Validate(model);

            if (!validation.IsValid)
                return validation;

            _repository.Create(model);
            return validation;
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return _repository.GetAll();
        }

        public DbSet<UsuarioModel> GetContext()
        {
            return _repository.GetContext();
        }

        public UsuarioModel GetEdicao(int? id)
        {
            return _repository.GetEdicao(id);
        }

        public UsuarioModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
        }

        public bool PostExclusao(int id)
        {
            throw new NotImplementedException();
        }

        public object PostLogin(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public ValidationResult PutEdicao(int id, UsuarioModel usuario)
        {
            var validation = new UsuarioValidation().Validate(usuario);

            if (!validation.IsValid)
                return validation;

            _repository.Update(usuario);
            return validation;
        }
    }
}
