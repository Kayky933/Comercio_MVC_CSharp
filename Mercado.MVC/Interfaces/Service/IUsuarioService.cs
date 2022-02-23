using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public ValidationResult PutEdicao(int id, UsuarioModel produto);
        public bool Delet(int id);
        public object PostLogin(UsuarioModel usuario);
    }
}
