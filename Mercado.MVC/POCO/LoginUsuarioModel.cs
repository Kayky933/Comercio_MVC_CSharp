using System;

namespace Mercado.MVC.POCO
{
    public class LoginUsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
