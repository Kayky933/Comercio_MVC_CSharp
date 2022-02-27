using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public ValidationResult Create(T model);
        public IEnumerable<T> GetAll(Guid? id);
        public T GetOneById(Guid? id);
        public DbSet<T> GetContext();
    }
}
