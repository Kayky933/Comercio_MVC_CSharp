using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {


        public UsuarioModel GetEdicao(int? id);

        public ValidationResult PutEdicao(int id, UsuarioModel usuario);

        public bool PostExclusao(int id);

        public object PostLogin(UsuarioModel usuario);
    }
}
