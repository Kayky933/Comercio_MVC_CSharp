using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class VendaValidation : AbstractValidator<VendaModel>
    {
        public VendaValidation()
        {
            RuleFor(x => x.Valor_Venda).NotEmpty().WithMessage(VendaErrorMessages.Valor_VendaNulo)
                .NotNull().WithMessage(VendaErrorMessages.Valor_VendaNulo)
                .LessThanOrEqualTo(1000000000).WithMessage(VendaErrorMessages.Valor_VendaMaximo)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.ValorMinimo);

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(VendaErrorMessages.QuantidadeNula)
                .NotNull().WithMessage(VendaErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(VendaErrorMessages.QuantidadeMinima)
                .LessThanOrEqualTo(1000000000).WithMessage(VendaErrorMessages.QuantidadeMaxima)
                .Must(x => x.GetType() == typeof(double)).WithMessage(VendaErrorMessages.QuantidadeTipoInvalido);

            RuleFor(x => x.Id_Produto).NotNull().WithMessage(VendaErrorMessages.Id_ProdutoNulo)
                .NotEmpty().WithMessage(VendaErrorMessages.Id_ProdutoNulo);


        }
    }
}
