using FluentValidation.Results;
using Mercado.MVC.Models;

namespace Mercado.MVC.Interfaces.Service
{
    public interface IVendaService : IBaseService<VendaModel>
    {
        public ValidationResult CreateVenda(VendaModel categoria);
    }
}
