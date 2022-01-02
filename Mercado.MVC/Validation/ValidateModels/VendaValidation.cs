using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class VendaValidation : AbstractValidator<VendaModel>
    {
        public VendaValidation(IProdutoRepository _produtoRepository)
        {
            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(VendaErrorMessages.QuantidadeNula)
                .NotNull().WithMessage(VendaErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.QuantidadeMinima)
                .Must(x => x.GetType() == typeof(int)).WithMessage(VendaErrorMessages.QuantidadeTipoInvalido);

            RuleFor(x => x.IdProduto).NotNull().WithMessage(VendaErrorMessages.IdProdutoNulo)
                .NotEmpty().WithMessage(VendaErrorMessages.IdProdutoNulo)
                .Must(x => _produtoRepository.GetOneById(x) != null).WithMessage(VendaErrorMessages.IdProdutoInexistente);

        }
    }
}
