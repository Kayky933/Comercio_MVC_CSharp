using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Mercado.MVC.Controllers
{
    public class ControllerPai : Controller
    {
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
