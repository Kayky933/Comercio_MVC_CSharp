using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public ValidationResult Create(T model);
        public IEnumerable<T> GetAll(int? id);
        public T GetOneById(int? id);
        public DbSet<T> GetContext();
    }
}
