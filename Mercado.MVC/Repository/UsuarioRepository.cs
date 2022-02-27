using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Mercado.MVC.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(MercadoMVCContext context) : base(context)
        {
        }
        public override IEnumerable<UsuarioModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id == id).ToList();
        }
        public void Delete(UsuarioModel entity)
        {
            GetContext().Remove(entity);
            SaveDb();
        }

        public UsuarioModel GetByEmail(string email)
        {
            return GetContext().Where(x => x.Email == email).FirstOrDefault();
        }

        public UsuarioModel GetBySenha(string senha, UsuarioModel usuario)
        {
            return GetContext().Where(x => x.Senha == SecurityService.Criptografar(senha) && x.Email == usuario.Email).FirstOrDefault();
        }

        public ClaimsPrincipal PostLogin(UsuarioModel usuario)
        {
            IList<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.SerialNumber, Convert.ToString(usuario.Id))
            };

            var minhaIdentity = new ClaimsIdentity(Claims, "Usuario");
            return new ClaimsPrincipal(new[] { minhaIdentity });
        }

    }
}
