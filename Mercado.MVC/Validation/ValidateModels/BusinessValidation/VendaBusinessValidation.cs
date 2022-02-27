using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels.BusinessValidation
{
    public class VendaBusinessValidation : AbstractValidator<VendaModel>
    {
        public VendaBusinessValidation(IProdutoRepository _produtoRepository, Guid idProd)
        {
            RuleFor(x => x.Quantidade).Must(x => _produtoRepository.GetOneById(idProd).Quantidade_Produto - x >= 0).WithMessage(VendaErrorMessages.QuantidadeEstoqueEsgotada);
            RuleFor(x => x.Id_Produto).Must(x => _produtoRepository.GetOneById(x) != null).WithMessage(VendaErrorMessages.Id_ProdutoInexistente);
        }
    }
}
