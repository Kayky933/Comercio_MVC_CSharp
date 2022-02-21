using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace Mercado.MVC.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(MercadoMVCContext context) : base(context)
        {
        }

        public UsuarioModel GetByEmail(string email)
        {
            return GetContext().Where(x => x.Email == email).FirstOrDefault();
        }

        public UsuarioModel GetBySenha(string senha, UsuarioModel usuario)
        {
            return GetContext().Where(x => x.Senha == senha && x.Id == usuario.Id).FirstOrDefault();
        }

        public UsuarioModel GetEdicao(int? id)
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal PostLogin(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

    }
}
