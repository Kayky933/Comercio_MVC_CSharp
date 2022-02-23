using Mercado.MVC.Models;
using System.Security.Claims;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        void Update(UsuarioModel entity);
        void Delete(UsuarioModel entity);
        public ClaimsPrincipal PostLogin(UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetBySenha(string senha, UsuarioModel usuario);

    }
}
