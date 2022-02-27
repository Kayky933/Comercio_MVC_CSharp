using FluentValidation.Results;
using Mercado.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Mercado.MVC.Controllers
{
    public class ControllerPai : Controller
    {
        internal void Autenticar()
        {
            var autenticacao = SecurityService.Autenticado(HttpContext);
            ViewBag.usuario = autenticacao == null ? "Não Logado" : autenticacao.Nome;
            ViewBag.email = autenticacao == null ? "Não Logado" : autenticacao.Email;
            ViewBag.usuarioId = autenticacao == null ? Guid.Empty : autenticacao.Id;
            ViewBag.autenticado = autenticacao == null ? false : true;
        }
        internal object MostrarErros(ValidationResult response, object model)
        {
            if (response.Errors.Select(e => e.ErrorMessage).ToList().GetType() == typeof(List<string>))
            {
                foreach (var item in response.Errors.ToList())
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return model;
        }
    }
}
