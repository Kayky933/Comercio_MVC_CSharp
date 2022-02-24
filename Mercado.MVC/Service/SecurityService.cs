using Mercado.MVC.POCO;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mercado.MVC.Service
{
    public static class SecurityService
    {
        public static LoginUsuarioModel Autenticado(HttpContext context)
        {
            string email = "";
            int usuarioId = Convert.ToInt32(null);
            LoginUsuarioModel res;
            if (context.User.Identity.IsAuthenticated)
            {
                string usuario = context.User.Identity.Name;

                foreach (var item in context.User.Claims)
                {
                    if (item.Type == ClaimTypes.Email)
                        email = item.Value;

                    if (item.Type == ClaimTypes.SerialNumber)
                        usuarioId = int.Parse(item.Value);
                }

                res = new LoginUsuarioModel()
                {
                    Nome = usuario,
                    Email = email,
                    Id = usuarioId
                };
                return res;
            }
            return null;
        }

        public static string Criptografar(string senha)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(senha));

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
