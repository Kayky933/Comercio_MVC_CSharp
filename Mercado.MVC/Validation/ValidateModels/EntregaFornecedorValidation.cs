using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class EntregaFornecedorValidation : AbstractValidator<EntregaFornecedorModel>
    {
        public EntregaFornecedorValidation()
        {
            RuleFor(x => x.DataEntrega).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.DataNula)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.DataNula)
                .Must(DataFutura).WithMessage(EntregaFornecedorErrorMessages.DataFutura);

            RuleFor(x => x.IdFornecedor).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.IdFornecedorNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.IdFornecedorNulo)
                .Must(x => x.GetType() == typeof(int)).WithMessage(EntregaFornecedorErrorMessages.IdFornecedorTipoInvalido);

            RuleFor(x => x.IdProduto).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.IdProdutoNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.IdProdutoNulo)
                .Must(x => x.GetType() == typeof(int)).WithMessage(EntregaFornecedorErrorMessages.IdProdutoTipoInvalido);

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.QuantidadeNula)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(EntregaFornecedorErrorMessages.QuantidadeMinima)
                .LessThanOrEqualTo(1000000000).WithMessage(EntregaFornecedorErrorMessages.QuantidadeMaxima)
                .Must(x => x.GetType() == typeof(double)).WithMessage(EntregaFornecedorErrorMessages.QuantidadeTipoInvalido);

            RuleFor(x => x.ValorUnidade).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.ValorUnidadeNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.ValorUnidadeNulo)
                .GreaterThanOrEqualTo(1).WithMessage(EntregaFornecedorErrorMessages.ValorUnidadeMinimo)
                .LessThanOrEqualTo(1000000000).WithMessage(EntregaFornecedorErrorMessages.ValorUnidadeMaximo)
                .Must(x => x.GetType() == typeof(decimal)).WithMessage(EntregaFornecedorErrorMessages.ValorUnidadeTipoInvalido);
        }
        private static bool DataFutura(DateTime data)
        {
            return data <= DateTime.Now;
        }
    }
}
