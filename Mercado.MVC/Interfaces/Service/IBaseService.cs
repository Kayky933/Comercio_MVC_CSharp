using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public ValidationResult Create(T model);
        public IEnumerable<T> GetAll();
        public T GetOneById(int? id);
        public bool Delet(int id);
        public DbSet<T> GetContext();
    }
}
