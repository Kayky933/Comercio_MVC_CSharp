using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class VendaValidation : AbstractValidator<VendaModel>
    {
        public VendaValidation()
        {
            RuleFor(x => x.ValorVenda).NotEmpty().WithMessage(VendaErrorMessages.ValorVendaNulo)
                .NotNull().WithMessage(VendaErrorMessages.ValorVendaNulo)
                .LessThanOrEqualTo(1000000000).WithMessage(VendaErrorMessages.ValorVendaMaximo)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.ValorMinimo);

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(VendaErrorMessages.QuantidadeNula)
                .NotNull().WithMessage(VendaErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.QuantidadeMinima)
                .LessThanOrEqualTo(1000000000).WithMessage(VendaErrorMessages.QuantidadeMaxima)
                .Must(x => x.GetType() == typeof(double)).WithMessage(VendaErrorMessages.QuantidadeTipoInvalido);

            RuleFor(x => x.IdProduto).NotNull().WithMessage(VendaErrorMessages.IdProdutoNulo)
                .NotEmpty().WithMessage(VendaErrorMessages.IdProdutoNulo);
                

        }
    }
}
