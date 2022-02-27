using FluentValidation.Results;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<CategoriaModel>
    {
        public ValidationResult PutCategory(CategoriaModel categoria);
        public bool Delet(Guid id);
    }
}
