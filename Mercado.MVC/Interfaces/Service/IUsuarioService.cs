using FluentValidation.Results;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public ValidationResult PutEdicao(Guid id, UsuarioModel produto);
        public bool Delet(Guid id);
        public object PostLogin(UsuarioModel usuario);
    }
}
