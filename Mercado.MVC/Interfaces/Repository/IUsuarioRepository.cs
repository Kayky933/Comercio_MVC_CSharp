using Mercado.MVC.Models;
using System.Security.Claims;

namespace Mercado.MVC.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        public ClaimsPrincipal PostLogin(UsuarioModel usuario);
        public UsuarioModel GetEdicao(int? id);
        public void Update(UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);

        public UsuarioModel GetBySenha(string senha, UsuarioModel usuario);

    }
}
