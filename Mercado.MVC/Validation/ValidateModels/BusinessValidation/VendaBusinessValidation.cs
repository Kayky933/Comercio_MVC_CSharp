using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels.BusinessValidation
{
    public class VendaBusinessValidation : AbstractValidator<VendaModel>
    {
        public VendaBusinessValidation(IProdutoRepository _produtoRepository, int idProd)
        {
            RuleFor(x => x.Quantidade).Must(x => _produtoRepository.GetOneById(idProd).QuantidadeProduto - x >= 0).WithMessage(VendaErrorMessages.QuantidadeEstoqueEsgotada);
            RuleFor(x => x.IdProduto).Must(x => _produtoRepository.GetOneById(x) != null).WithMessage(VendaErrorMessages.IdProdutoInexistente);
        }
    }
}
