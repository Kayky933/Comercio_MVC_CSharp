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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult Create(UsuarioModel model)
        {

            var validacao = ValidarUsuario(model);
            if (!validacao.IsValid)
                return validacao;

            model.Senha = SecurityService.Criptografar(model.Senha);
            _repository.Create(model);
            return validacao;
        }

        public IEnumerable<UsuarioModel> GetAll(int? id)
        {
            return _repository.GetAll(id);
        }
        public DbSet<UsuarioModel> GetContext()
        {
            return _repository.GetContext();
        }
        public UsuarioModel GetOneById(int? id)
        {
            return _repository.GetOneById(id);
        }

        public bool Delet(int id)
        {
            var usuario = _repository.GetOneById(id);
            if (usuario == null)
                return false;
            try
            {
                _repository.Delete(usuario);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public object PostLogin(UsuarioModel usuario)
        {
            var getUsuario = _repository.GetByEmail(usuario.Email);
            var senha = _repository.GetBySenha(usuario.Senha, usuario);

            if (getUsuario.Email == null || senha == null)
                return usuario;

            return _repository.PostLogin(getUsuario);
        }

        public ValidationResult PutEdicao(int id, UsuarioModel usuario)
        {
            var validacao = ValidarUsuario(usuario);
            if (!validacao.IsValid)
                return validacao;

            _repository.Update(usuario);
            return validacao;
        }

        private ValidationResult ValidarUsuario(UsuarioModel usuario)
        {
            var validacao = new UsuarioValidation().Validate(usuario);
            if (!validacao.IsValid)
                return validacao;

            var validacaoBusiness = new UsuarioBusinessValidation(_repository).Validate(usuario);
            if (!validacaoBusiness.IsValid)
                return validacaoBusiness;

            return validacao;
        }
    }
}
